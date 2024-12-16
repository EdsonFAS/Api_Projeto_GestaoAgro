using GestaoAgro.DataContexts;
using GestaoAgro.Dtos;
using GestaoAgro.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoAgro.Controllers
{
    [ApiController]
    [Route("RebanhoAlimentacao")]
    public class RebanhoAlimentacaoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RebanhoAlimentacaoController(AppDbContext context)
        {
            _context = context;
        }

        // GET all RebanhoAlimentacao
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
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

                return Ok(listaRebanhoAlimentacao);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // GET RebanhoAlimentacao by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var rebanhoAlimentacao = await _context.RebanhoAlimentacao
                    .Include(ra => ra.Rebanho)
                    .Include(ra => ra.Alimentacao)
                    .FirstOrDefaultAsync(ra => ra.Id == id);

                if (rebanhoAlimentacao == null)
                {
                    return NotFound($"RebanhoAlimentacao #{id} não encontrada");
                }

                return Ok(rebanhoAlimentacao);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // POST create new RebanhoAlimentacao
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RebanhoAlimentacaoModel item)
        {
            try
            {
                var rebanhoAlimentacao = new RebanhoAlimentacaoModel
                {
                    Rebanho = item.Rebanho,
                    Alimentacao = item.Alimentacao
                };

                await _context.RebanhoAlimentacao.AddAsync(rebanhoAlimentacao);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = rebanhoAlimentacao.Id }, rebanhoAlimentacao);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // PUT update RebanhoAlimentacao by ID
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RebanhoAlimentacaoModel item)
        {
            try
            {
                var rebanhoAlimentacao = await _context.RebanhoAlimentacao.FindAsync(id);

                if (rebanhoAlimentacao is null)
                {
                    return NotFound();
                }

                rebanhoAlimentacao.Rebanho = item.Rebanho;
                rebanhoAlimentacao.Alimentacao = item.Alimentacao;

                _context.RebanhoAlimentacao.Update(rebanhoAlimentacao);
                await _context.SaveChangesAsync();

                return Ok(rebanhoAlimentacao);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // DELETE RebanhoAlimentacao by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var rebanhoAlimentacao = await _context.RebanhoAlimentacao.FindAsync(id);

                if (rebanhoAlimentacao is null)
                {
                    return NotFound();
                }

                _context.RebanhoAlimentacao.Remove(rebanhoAlimentacao);
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
