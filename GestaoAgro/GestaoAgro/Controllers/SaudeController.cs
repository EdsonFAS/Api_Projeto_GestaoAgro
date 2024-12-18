using GestaoAgro.DataContexts;
using GestaoAgro.Dtos;
using GestaoAgro.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoAgro.Controllers
{
    [ApiController]
    [Route("Saude")]
    public class SaudeController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Construtor que injeta o contexto do banco de dados
        public SaudeController(AppDbContext context)
        {
            _context = context;
        }

        // GET all Saúde records - Retorna todos os registros de saúde
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaSaude = await _context.Saude.Include(s => s.Animal).ToListAsync();

                // Verifica se não há registros
                if (listaSaude == null || !listaSaude.Any())
                {
                    return NotFound("Nenhum registro de saúde encontrado.");
                }

                return Ok(listaSaude);
            }
            catch (Exception e)
            {
                return Problem($"Erro ao tentar recuperar os registros de saúde: {e.Message}");
            }
        }

        // GET Saúde by ID - Retorna um registro específico pelo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var saude = await _context.Saude.Include(s => s.Animal)
                                                 .FirstOrDefaultAsync(s => s.Id == id);

                // Se o registro não for encontrado
                if (saude == null)
                {
                    return NotFound($"Saúde com ID {id} não encontrada.");
                }

                return Ok(saude);
            }
            catch (Exception e)
            {
                return Problem($"Erro ao tentar recuperar o registro de saúde com ID {id}: {e.Message}");
            }
        }

        // POST create new Saúde record - Cria um novo registro de saúde
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SaudeModel item)
        {
            try
            {
                // Valida se o corpo da requisição é nulo
                if (item == null)
                {
                    return BadRequest("Dados inválidos. Certifique-se de enviar os campos corretamente.");
                }

                // Criação de um novo objeto de saúde
                var saude = new SaudeModel
                {
                    Veterinario = item.Veterinario,
                    Status = item.Status,
                    Apetite = item.Apetite,
                    Temperatura = item.Temperatura,
                    CodigoBrinco = item.CodigoBrinco,
                    DataVerificacao = item.DataVerificacao
                };

                // Adiciona o novo registro ao banco de dados
                await _context.Saude.AddAsync(saude);
                await _context.SaveChangesAsync();

                // Retorna o status 201 Created com o novo objeto criado
                return CreatedAtAction(nameof(GetById), new { id = saude.Id }, saude);
            }
            catch (Exception e)
            {
                return Problem($"Erro ao tentar criar o registro de saúde: {e.Message}");
            }
        }

        // PUT update Saúde by ID - Atualiza um registro de saúde existente pelo ID
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SaudeModel item)
        {
            try
            {
                // Verifica se o corpo da requisição está vazio
                if (item == null)
                {
                    return BadRequest("Dados inválidos. Certifique-se de enviar os campos corretamente.");
                }

                // Busca o registro de saúde pelo ID
                var saude = await _context.Saude.FindAsync(id);

                // Se o registro não for encontrado
                if (saude == null)
                {
                    return NotFound($"Saúde com ID {id} não encontrada.");
                }

                // Atualiza os dados do registro
                saude.Veterinario = item.Veterinario;
                saude.Status = item.Status;
                saude.Apetite = item.Apetite;
                saude.Temperatura = item.Temperatura;
                saude.CodigoBrinco = item.CodigoBrinco;
                saude.DataVerificacao = item.DataVerificacao;

                // Atualiza no banco de dados
                _context.Saude.Update(saude);
                await _context.SaveChangesAsync();

                return Ok(saude);
            }
            catch (Exception e)
            {
                return Problem($"Erro ao tentar atualizar o registro de saúde com ID {id}: {e.Message}");
            }
        }

        // DELETE Saúde by ID - Deleta um registro de saúde pelo ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                // Busca o registro de saúde pelo ID
                var saude = await _context.Saude.FindAsync(id);

                // Se o registro não for encontrado
                if (saude == null)
                {
                    return NotFound($"Saúde com ID {id} não encontrada.");
                }

                // Remove o registro do banco de dados
                _context.Saude.Remove(saude);
                await _context.SaveChangesAsync();

                return Ok($"Saúde com ID {id} foi removida com sucesso.");
            }
            catch (Exception e)
            {
                return Problem($"Erro ao tentar excluir o registro de saúde com ID {id}: {e.Message}");
            }
        }
    }
}