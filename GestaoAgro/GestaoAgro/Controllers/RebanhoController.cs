using GestaoAgro.DataContexts;
using GestaoAgro.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoAgro.Controllers
{
    [Authorize]
    [ApiController]
    [Route("rebanho")]
    public class RebanhoController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Construtor que injeta o contexto do banco de dados
        public RebanhoController(AppDbContext context)
        {
            _context = context;
        }

        // GET all Rebanhos
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                // Consulta todos os rebanhos com seus animais associados
                var listaRebanho = await _context.Rebanho
                    .Include(p => p.Animal)
                    .Select(p => new
                    {
                        p.Id,
                        p.Tipo,
                        p.Destino,
                        Animal = new
                        {
                            CodigoBrinco = p.Animal.CodigoBrinco,
                            p.Animal.Raca
                        }
                    })
                    .ToListAsync();

                // Se não houver rebanhos, retorna uma mensagem de erro
                if (!listaRebanho.Any())
                {
                    return NotFound("Nenhum rebanho encontrado.");
                }

                return Ok(listaRebanho);
            }
            catch (Exception e)
            {
                // Captura erros e retorna mensagem de problema
                return Problem($"Erro ao tentar recuperar a lista de rebanhos: {e.Message}");
            }
        }

        // GET Rebanho by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                // Busca o rebanho pelo ID com os dados do animal
                var rebanho = await _context.Rebanho
                    .Include(p => p.Animal)
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();

                // Se não encontrado, retorna mensagem de erro
                if (rebanho == null)
                {
                    return NotFound($"Rebanho #{id} não encontrado.");
                }

                return Ok(rebanho);
            }
            catch (Exception e)
            {
                // Captura erros e retorna mensagem de problema
                return Problem($"Erro ao tentar recuperar o rebanho com ID {id}: {e.Message}");
            }
        }

        // POST create new Rebanho
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RebanhoModel item)
        {
            try
            {
                // Verifica se os dados do corpo são válidos
                if (item == null)
                {
                    return BadRequest("Dados inválidos. Certifique-se de enviar os campos corretamente.");
                }

                // Cria o novo rebanho
                var rebanho = new RebanhoModel
                {
                    Tipo = item.Tipo,
                    Destino = item.Destino,
                    CodigoBrinco = item.CodigoBrinco
                };

                // Adiciona o rebanho ao contexto e salva no banco
                await _context.Rebanho.AddAsync(rebanho);
                await _context.SaveChangesAsync();

                // Retorna o rebanho criado com status 201
                return CreatedAtAction(nameof(GetById), new { id = rebanho.Id }, rebanho);
            }
            catch (Exception e)
            {
                // Captura erros e retorna mensagem de problema
                return Problem($"Erro ao tentar criar o rebanho: {e.Message}");
            }
        }

        // PUT update Rebanho by ID
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RebanhoModel item)
        {
            try
            {
                // Verifica se os dados do corpo são válidos
                if (item == null)
                {
                    return BadRequest("Dados inválidos. Certifique-se de enviar os campos corretamente.");
                }

                // Busca o rebanho pelo ID
                var rebanho = await _context.Rebanho.FindAsync(id);

                // Se não encontrado, retorna mensagem de erro
                if (rebanho == null)
                {
                    return NotFound($"Rebanho #{id} não encontrado.");
                }

                // Atualiza os dados do rebanho
                rebanho.Tipo = item.Tipo;
                rebanho.Destino = item.Destino;
                rebanho.CodigoBrinco = item.CodigoBrinco;

                // Atualiza no banco de dados
                _context.Rebanho.Update(rebanho);
                await _context.SaveChangesAsync();

                return Ok(rebanho); // Retorna o rebanho atualizado
            }
            catch (Exception e)
            {
                // Captura erros e retorna mensagem de problema
                return Problem($"Erro ao tentar atualizar o rebanho com ID {id}: {e.Message}");
            }
        }

        // DELETE Rebanho by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                // Busca o rebanho pelo ID
                var rebanho = await _context.Rebanho.FindAsync(id);
                if (rebanho == null)
                {
                    return NotFound($"Rebanho #{id} não encontrado.");
                }

                // Remove registros dependentes na tabela RebanhoAlimentacao
                var dependentes = _context.RebanhoAlimentacao.Where(ra => ra.IdRebanho == id);
                _context.RebanhoAlimentacao.RemoveRange(dependentes);

                // Remove o rebanho
                _context.Rebanho.Remove(rebanho);
                await _context.SaveChangesAsync();

                return Ok($"Rebanho #{id} e seus registros relacionados foram removidos com sucesso.");
            }
            catch (DbUpdateException ex)
            {
                // Captura exceções de banco de dados e retorna a mensagem de erro
                var innerExceptionMessage = ex.InnerException?.Message;
                return Problem($"Erro ao tentar excluir o rebanho com ID {id}: {innerExceptionMessage}");
            }
            catch (Exception e)
            {
                // Captura erros gerais e retorna a mensagem de erro
                return Problem($"Erro ao tentar excluir o rebanho com ID {id}: {e.Message}");
            }
        }
    }
}