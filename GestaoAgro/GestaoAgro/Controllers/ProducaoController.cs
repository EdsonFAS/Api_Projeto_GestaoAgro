using GestaoAgro.DataContexts;
using GestaoAgro.Dtos;
using GestaoAgro.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoAgro.Controllers
{
    [ApiController] // Indica que a classe é um controlador de API
    [Route("producao")] // Define a rota base para os métodos da API
    public class ProducaoController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Construtor que recebe o contexto da base de dados para interagir com o banco
        public ProducaoController(AppDbContext context)
        {
            _context = context; // Inicializa o contexto do banco de dados
        }

        // GET all producoes - Retorna todas as produções com dados do animal relacionado
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaProducao = await _context.Producao
                    .Include(p => p.Animal) // Inclui os dados do animal
                    .Select(p => new
                    {
                        p.Id,
                        p.TipoProducao,
                        p.Data,
                        p.QuantidadeProduzida,
                        Animal = new { p.Animal.CodigoBrinco, p.Animal.Raca }
                    })
                    .ToListAsync();

                return Ok(listaProducao); // Retorna as produções com status 200 OK
            }
            catch (Exception e)
            {
                return Problem($"Erro ao tentar recuperar as produções: {e.Message}"); // Retorna erro se falhar
            }
        }

        // GET producao by ID - Retorna uma produção específica pelo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var producao = await _context.Producao
                    .Include(p => p.Animal) // Inclui dados do animal
                    .FirstOrDefaultAsync(p => p.Id == id); // Filtra pela produção pelo ID

                if (producao == null)
                {
                    return NotFound($"Producao #{id} não encontrada"); // Retorna erro 404 se não encontrar
                }

                return Ok(producao); // Retorna a produção com status 200 OK
            }
            catch (Exception e)
            {
                return Problem($"Erro ao tentar recuperar a produção com ID {id}: {e.Message}"); // Retorna erro se falhar
            }
        }

        // POST create new producao - Cria uma nova produção no banco
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProducaoModel item)
        {
            try
            {
                var producao = new ProducaoModel
                {
                    TipoProducao = item.TipoProducao, // Define tipo de produção
                    Data = item.Data, // Define a data da produção
                    QuantidadeProduzida = item.QuantidadeProduzida, // Define a quantidade
                    CodigoBrinco = item.CodigoBrinco // Relaciona com o animal pelo código de brinco
                };

                await _context.Producao.AddAsync(producao);
                await _context.SaveChangesAsync(); // Salva no banco

                return CreatedAtAction(nameof(GetById), new { id = producao.Id }, producao); // Retorna a produção criada com status 201
            }
            catch (Exception e)
            {
                return Problem($"Erro ao tentar criar a produção: {e.Message}"); // Retorna erro se falhar
            }
        }

        // PUT update producao by ID - Atualiza uma produção existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProducaoModel item)
        {
            try
            {
                var producao = await _context.Producao.FindAsync(id);

                if (producao == null)
                {
                    return NotFound($"Producao #{id} não encontrada para atualização"); // Retorna erro 404 se não encontrar
                }

                // Atualiza os dados da produção
                producao.TipoProducao = item.TipoProducao;
                producao.Data = item.Data;
                producao.QuantidadeProduzida = item.QuantidadeProduzida;
                producao.CodigoBrinco = item.CodigoBrinco;

                _context.Producao.Update(producao);
                await _context.SaveChangesAsync(); // Salva as alterações no banco

                return Ok(producao); // Retorna a produção atualizada com status 200 OK
            }
            catch (Exception e)
            {
                return Problem($"Erro ao tentar atualizar a produção com ID {id}: {e.Message}");  // Retorna erro se falhar
            }
        }

        // DELETE producao by ID - Exclui uma produção específica
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var producao = await _context.Producao.FindAsync(id);

                if (producao == null)
                {
                    return NotFound($"Producao #{id} não encontrada para exclusão");  // Retorna erro 404 se não encontrar
                }

                _context.Producao.Remove(producao);
                await _context.SaveChangesAsync();  // Salva as alterações no banco

                return Ok($"Producao #{id} excluída com sucesso");  // Retorna sucesso com status 200 OK
            }
            catch (Exception e)
            {
                return Problem($"Erro ao tentar excluir a produção com ID {id}: {e.Message}");  // Retorna erro se falhar
            }
        }
    }
}