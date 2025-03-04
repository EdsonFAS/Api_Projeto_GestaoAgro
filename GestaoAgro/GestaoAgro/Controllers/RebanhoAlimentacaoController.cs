using GestaoAgro.DataContexts;
using GestaoAgro.Dtos;
using GestaoAgro.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoAgro.Controllers
{
    [Authorize]
    [ApiController] // Define que a classe é um controlador de API
    [Route("rebanhoalimentacao")] // Define o endpoint base para os métodos do controlador
    public class RebanhoAlimentacaoController : ControllerBase
    {
        private readonly AppDbContext _context; // Injeção de dependência do contexto do banco de dados

        public RebanhoAlimentacaoController(AppDbContext context)
        {
            _context = context; // Inicializa o contexto do banco de dados
        }

        // GET all RebanhoAlimentacao
        [HttpGet] // Define que esse método é um endpoint GET
        public async Task<IActionResult> GetAll()
        {
            try
            {
                // Consulta todos os registros de RebanhoAlimentacao com suas respectivas entidades Rebanho e Alimentacao
                var listaRebanhoAlimentacao = await _context.RebanhoAlimentacao
                    .Include(ra => ra.Rebanho)
                    .Include(ra => ra.Alimentacao)
                    .Select(ra => new
                    {
                        ra.Id,
                        RebanhoId = ra.Rebanho.Id,
                        AlimentacaoId = ra.Alimentacao.Id,
                        RebanhoTipo = ra.Rebanho.Tipo,
                        AlimentacaoNome = ra.Alimentacao.Nome
                    })
                    .ToListAsync();

                // Retorna uma lista de RebanhoAlimentacao ou uma mensagem de erro caso não exista registros
                if (listaRebanhoAlimentacao.Count == 0)
                {
                    return NotFound("Nenhuma alimentação de rebanho encontrada.");
                }

                return Ok(listaRebanhoAlimentacao); // Retorna os dados com status 200 OK
            }
            catch (Exception e)
            {
                return Problem($"Erro ao tentar recuperar a lista de RebanhoAlimentacao: {e.Message}"); // Retorna erro se houver exceção
            }
        }

        // GET RebanhoAlimentacao by ID
        [HttpGet("{id}")] // Define que esse método é um endpoint GET com um parâmetro de ID
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                // Busca o RebanhoAlimentacao pelo ID, incluindo as entidades associadas
                var rebanhoAlimentacao = await _context.RebanhoAlimentacao
                    .Include(ra => ra.Rebanho)
                    .Include(ra => ra.Alimentacao)
                    .FirstOrDefaultAsync(ra => ra.Id == id);

                // Retorna um erro caso não encontre o registro
                if (rebanhoAlimentacao == null)
                {
                    return NotFound($"RebanhoAlimentacao com ID {id} não encontrado.");
                }

                return Ok(rebanhoAlimentacao); // Retorna o objeto encontrado com status 200 OK
            }
            catch (Exception e)
            {
                return Problem($"Erro ao tentar recuperar a RebanhoAlimentacao com ID {id}: {e.Message}"); // Retorna erro em caso de exceção
            }
        }

        // POST create new RebanhoAlimentacao
        [HttpPost] // Define que esse método é um endpoint POST
        public async Task<IActionResult> Post([FromBody] RebanhoAlimentacaoModel item)
        {
            try
            {
                // Verifica se os campos obrigatórios estão presentes
                if (item.Rebanho == null || item.Alimentacao == null)
                {
                    return BadRequest("Rebanho e Alimentação são campos obrigatórios.");
                }

                // Cria uma nova entrada de RebanhoAlimentacao
                var rebanhoAlimentacao = new RebanhoAlimentacaoModel
                {
                    Rebanho = item.Rebanho,
                    Alimentacao = item.Alimentacao
                };

                // Adiciona e salva a nova entrada no banco de dados
                await _context.RebanhoAlimentacao.AddAsync(rebanhoAlimentacao);
                await _context.SaveChangesAsync();

                // Retorna a nova entrada criada com status 201 Created
                return CreatedAtAction(nameof(GetById), new { id = rebanhoAlimentacao.Id }, rebanhoAlimentacao);
            }
            catch (Exception e)
            {
                return Problem($"Erro ao tentar criar a RebanhoAlimentacao: {e.Message}"); // Retorna erro em caso de exceção
            }
        }

        // PUT update RebanhoAlimentacao by ID
        [HttpPut("{id}")] // Define que esse método é um endpoint PUT para atualizar um recurso específico pelo ID
        public async Task<IActionResult> Put(int id, [FromBody] RebanhoAlimentacaoModel item)
        {
            try
            {
                // Verifica se os campos obrigatórios estão presentes
                if (item.Rebanho == null || item.Alimentacao == null)
                {
                    return BadRequest("Rebanho e Alimentação são campos obrigatórios.");
                }

                // Busca o RebanhoAlimentacao pelo ID para atualização
                var rebanhoAlimentacao = await _context.RebanhoAlimentacao.FindAsync(id);

                // Retorna um erro se o registro não for encontrado
                if (rebanhoAlimentacao == null)
                {
                    return NotFound($"RebanhoAlimentacao com ID {id} não encontrado para atualização.");
                }

                // Atualiza as informações
                rebanhoAlimentacao.Rebanho = item.Rebanho;
                rebanhoAlimentacao.Alimentacao = item.Alimentacao;

                // Atualiza o registro no banco de dados
                _context.RebanhoAlimentacao.Update(rebanhoAlimentacao);
                await _context.SaveChangesAsync();

                return Ok(rebanhoAlimentacao); // Retorna o objeto atualizado
            }
            catch (Exception e)
            {
                return Problem($"Erro ao tentar atualizar a RebanhoAlimentacao com ID {id}: {e.Message}"); // Retorna erro em caso de exceção
            }
        }

        // DELETE RebanhoAlimentacao by ID
        [HttpDelete("{id}")] // Define que esse método é um endpoint DELETE para remover um recurso específico pelo ID
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                // Busca o RebanhoAlimentacao pelo ID para exclusão
                var rebanhoAlimentacao = await _context.RebanhoAlimentacao.FindAsync(id);

                // Retorna erro se o registro não for encontrado
                if (rebanhoAlimentacao == null)
                {
                    return NotFound($"RebanhoAlimentacao com ID {id} não encontrado para exclusão.");
                }

                // Remove o registro do banco de dados
                _context.RebanhoAlimentacao.Remove(rebanhoAlimentacao);
                await _context.SaveChangesAsync();

                return Ok($"RebanhoAlimentacao com ID {id} excluída com sucesso."); // Retorna sucesso na exclusão
            }
            catch (Exception e)
            {
                return Problem($"Erro ao tentar excluir a RebanhoAlimentacao com ID {id}: {e.Message}"); // Retorna erro em caso de exceção
            }
        }
    }
}