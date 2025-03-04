using GestaoAgro.DataContexts;
using GestaoAgro.Dtos;
using GestaoAgro.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoAgro.Controllers
{
    [Authorize]
    [ApiController] // Define a classe como um controlador de API
    [Route("alimentacao")] // Define a rota base para acessar este controlador
    public class AlimentacaoController : ControllerBase // Herda de ControllerBase para APIs sem views
    {
        private readonly AppDbContext _context; // Injeta o contexto do banco de dados

        public AlimentacaoController(AppDbContext context)
        {
            _context = context; // Inicializa o contexto
        }

        // Método GET: Retorna todas as alimentações
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaAlimentacao = await _context.Alimentacao.ToListAsync(); // Busca todas as alimentações
                return Ok(listaAlimentacao); // Retorna a lista no formato HTTP 200 (OK)
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, title: "Erro ao buscar lista de alimentações", statusCode: 500); // Retorna erro caso falhe
            }
        }

        // Método GET: Retorna uma alimentação específica pelo ID
        [HttpGet("{id}")] // Inclui o ID na rota
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var alimentacao = await _context.Alimentacao.FindAsync(id); // Busca a alimentação pelo ID
                if (alimentacao == null) // Verifica se o item existe
                {
                    return NotFound(new { mensagem = $"Alimentação com ID {id} não encontrada." }); // Retorna 404 se não encontrado
                }
                return Ok(alimentacao); // Retorna o item encontrado
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, title: "Erro ao buscar alimentação por ID", statusCode: 500); // Retorna erro caso falhe
            }
        }

        // Método POST: Cria uma nova alimentação
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AlimentacaoModel item) // Recebe os dados no corpo da requisição
        {
            try
            {
                if (item == null) // Verifica se os dados são nulos
                {
                    return BadRequest(new { mensagem = "Os dados fornecidos são inválidos." }); // Retorna 400 se inválido
                }

                var alimentacao = new AlimentacaoModel // Cria um novo item
                {
                    Fornecedor = item.Fornecedor,
                    Nome = item.Nome,
                    QuantidadeEstoque = item.QuantidadeEstoque,
                    DataValidade = item.DataValidade,
                    DataEntrega = item.DataEntrega
                };

                await _context.Alimentacao.AddAsync(alimentacao); // Adiciona o item ao banco
                await _context.SaveChangesAsync(); // Salva as mudanças no banco

                return CreatedAtAction(nameof(GetById), new { id = alimentacao.Id }, alimentacao); // Retorna 201 (Created) com a URL do novo recurso
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, title: "Erro ao criar nova alimentação", statusCode: 500); // Retorna erro caso falhe
            }
        }

        // Método PUT: Atualiza uma alimentação existente
        [HttpPut("{id}")] // Inclui o ID na rota
        public async Task<IActionResult> Put(int id, [FromBody] AlimentacaoModel item)
        {
            try
            {
                if (item == null) // Verifica se os dados são nulos
                {
                    return BadRequest(new { mensagem = "Os dados fornecidos são inválidos." }); // Retorna 400 se inválido
                }

                var alimentacao = await _context.Alimentacao.FindAsync(id); // Busca o item pelo ID
                if (alimentacao == null) // Verifica se o item existe
                {
                    return NotFound(new { mensagem = $"Alimentação com ID {id} não encontrada." }); // Retorna 404 se não encontrado
                }

                // Atualiza os dados do item
                alimentacao.Fornecedor = item.Fornecedor;
                alimentacao.Nome = item.Nome;
                alimentacao.QuantidadeEstoque = item.QuantidadeEstoque;
                alimentacao.DataValidade = item.DataValidade;
                alimentacao.DataEntrega = item.DataEntrega;

                _context.Alimentacao.Update(alimentacao); // Marca o item como atualizado
                await _context.SaveChangesAsync(); // Salva as mudanças no banco

                return Ok(alimentacao); // Retorna o item atualizado
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, title: "Erro ao atualizar alimentação", statusCode: 500); // Retorna erro caso falhe
            }
        }

        // Método DELETE: Remove uma alimentação existente
        [HttpDelete("{id}")] // Inclui o ID na rota
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var alimentacao = await _context.Alimentacao.FindAsync(id); // Busca o item pelo ID
                if (alimentacao == null) // Verifica se o item existe
                {
                    return NotFound(new { mensagem = $"Alimentação com ID {id} não encontrada." }); // Retorna 404 se não encontrado
                }

                _context.Alimentacao.Remove(alimentacao); // Remove o item do banco
                await _context.SaveChangesAsync(); // Salva as mudanças no banco

                return Ok(new { mensagem = $"Alimentação com ID {id} foi removida com sucesso." }); // Retorna 200 com a mensagem de sucesso
            }
            catch (Exception e)
            {
                return Problem(detail: e.Message, title: "Erro ao remover alimentação", statusCode: 500); // Retorna erro caso falhe
            }
        }
    }
}