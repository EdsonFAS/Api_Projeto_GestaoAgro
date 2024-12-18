using GestaoAgro.DataContexts;
using GestaoAgro.Dtos;
using GestaoAgro.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoAgro.Controladores
{
    [ApiController] // Define que a classe é um controlador de API
    [Route("Pastagem")] // Define o caminho da rota para acessar as ações
    public class PastagemController : ControllerBase
    {
        private readonly AppDbContext _context; // Contexto do banco de dados

        public PastagemController(AppDbContext context)
        {
            _context = context; // Injeta o contexto no controlador
        }

        // OBTER todos as pastagens
        [HttpGet] // Define o método HTTP como GET
        public async Task<IActionResult> GetAll()
        {
            try
            {
                // Recupera a lista de pastagens com dados relacionados ao animal
                var listaPastagem = await _context.Pastagem
                    .Include(p => p.Animal) // Inclui os dados do Animal relacionado
                    .Select(p => new
                    {
                        p.Id,
                        p.AreaPastagem,
                        p.LocalizacaoPastagem,
                        p.Periodo,
                        Animal = new
                        {
                            CodigoBrinco = p.Animal.CodigoBrinco,
                            p.Animal.Raca
                        }
                    })
                    .ToListAsync();

                return Ok(listaPastagem); // Retorna a lista de pastagens com sucesso
            }
            catch (Exception e)
            {
                return Problem($"Erro ao obter a lista de pastagens: {e.Message}"); // Retorna erro em caso de falha
            }
        }

        // GET pastagem por ID
        [HttpGet("{id}")] // Define o método GET para um ID específico
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var pastagem = await _context.Pastagem
                    .Include(p => p.Animal) // Inclui dados do Animal
                    .Where(p => p.Id == id) // Filtra pela ID
                    .FirstOrDefaultAsync();

                if (pastagem == null)
                {
                    return NotFound($"Pastagem com ID #{id} não encontrada."); // Retorna erro se não encontrar
                }

                return Ok(pastagem); // Retorna a pastagem encontrada
            }
            catch (Exception e)
            {
                return Problem($"Erro ao obter a pastagem com ID {id}: {e.Message}"); // Retorna erro em caso de falha
            }
        }

        // POST criar nova pastagem
        [HttpPost] // Define o método HTTP como POST
        public async Task<IActionResult> Post([FromBody] PastagemModel item)
        {
            try
            {
                var pastagem = new PastagemModel
                {
                    AreaPastagem = item.AreaPastagem,
                    LocalizacaoPastagem = item.LocalizacaoPastagem,
                    Periodo = item.Periodo,
                    CodigoBrinco = item.CodigoBrinco // Relacionamento com o Animal
                };

                await _context.Pastagem.AddAsync(pastagem); // Adiciona a nova pastagem
                await _context.SaveChangesAsync(); // Salva no banco de dados
                return CreatedAtAction(nameof(GetById), new { id = pastagem.Id }, pastagem); // Retorna a nova pastagem criada
            }
            catch (Exception e)
            {
                return Problem($"Erro ao criar a pastagem: {e.Message}"); // Retorna erro em caso de falha
            }
        }

        // PUT atualização pastagem por ID
        [HttpPut("{id}")] // Define o método HTTP como PUT para atualizar por ID
        public async Task<IActionResult> Put(int id, [FromBody] PastagemModel item)
        {
            try
            {
                var pastagem = await _context.Pastagem.FindAsync(id); // Encontra a pastagem pelo ID

                if (pastagem == null)
                {
                    return NotFound($"Pastagem com ID #{id} não encontrada para atualização."); // Retorna erro se não encontrar
                }

                // Atualiza as propriedades da pastagem
                pastagem.AreaPastagem = item.AreaPastagem;
                pastagem.LocalizacaoPastagem = item.LocalizacaoPastagem;
                pastagem.Periodo = item.Periodo;
                pastagem.CodigoBrinco = item.CodigoBrinco;

                _context.Pastagem.Update(pastagem); // Atualiza no banco de dados
                await _context.SaveChangesAsync(); // Salva as mudanças
                return Ok(pastagem); // Retorna a pastagem atualizada
            }
            catch (Exception e)
            {
                return Problem($"Erro ao atualizar a pastagem com ID {id}: {e.Message}"); // Retorna erro em caso de falha
            }
        }

        // DELETE pastagem por ID
        [HttpDelete("{id}")] // Define o método HTTP como DELETE para remover por ID
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var pastagem = await _context.Pastagem.FindAsync(id); // Encontra a pastagem pelo ID

                if (pastagem == null)
                {
                    return NotFound($"Pastagem com ID #{id} não encontrada para remoção."); // Retorna erro se não encontrar
                }

                _context.Pastagem.Remove(pastagem); // Remove a pastagem
                await _context.SaveChangesAsync(); // Salva as mudanças no banco
                return Ok("Pastagem removida com sucesso."); // Retorna sucesso na remoção
            }
            catch (DbUpdateException dbEx)
            {
                return Problem($"Erro ao atualizar o banco de dados ao tentar remover a pastagem com ID #{id}: {dbEx.InnerException?.Message ?? dbEx.Message}"); // Retorna erro de banco de dados
            }
            catch (Exception e)
            {
                return Problem($"Erro ao remover a pastagem com ID #{id}: {e.Message}"); // Retorna erro em caso de falha
            }
        }
    }
}