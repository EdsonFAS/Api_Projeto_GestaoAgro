using GestaoAgro.DataContexts;
using GestaoAgro.Dtos;
using GestaoAgro.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoAgro.Controllers
{
    [ApiController]
    [Route("Alimentacao")]
    public class AlimentacaoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlimentacaoController(AppDbContext context)
        {
            _context = context;
        }

        // GET all Alimentacao
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaAlimentacao = await _context.Alimentacao.ToListAsync();
                return Ok(listaAlimentacao);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // GET Alimentacao by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var alimentacao = await _context.Alimentacao.FindAsync(id);

                if (alimentacao == null)
                {
                    return NotFound($"Alimentação #{id} não encontrada");
                }

                return Ok(alimentacao);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // POST create new Alimentacao
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AlimentacaoModel item)
        {
            try
            {
                var alimentacao = new AlimentacaoModel
                {
                    Fornecedor = item.Fornecedor,
                    Nome = item.Nome,
                    QuantidadeEstoque = item.QuantidadeEstoque,
                    DataValidade = item.DataValidade,
                    DataEntrega = item.DataEntrega
                };

                await _context.Alimentacao.AddAsync(alimentacao);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = alimentacao.Id }, alimentacao);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // PUT update Alimentacao by ID
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AlimentacaoModel item)
        {
            try
            {
                var alimentacao = await _context.Alimentacao.FindAsync(id);

                if (alimentacao is null)
                {
                    return NotFound();
                }

                alimentacao.Fornecedor = item.Fornecedor;
                alimentacao.Nome = item.Nome;
                alimentacao.QuantidadeEstoque = item.QuantidadeEstoque;
                alimentacao.DataValidade = item.DataValidade;
                alimentacao.DataEntrega = item.DataEntrega;

                _context.Alimentacao.Update(alimentacao);
                await _context.SaveChangesAsync();

                return Ok(alimentacao);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // DELETE Alimentacao by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var alimentacao = await _context.Alimentacao.FindAsync(id);

                if (alimentacao is null)
                {
                    return NotFound();
                }

                _context.Alimentacao.Remove(alimentacao);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
