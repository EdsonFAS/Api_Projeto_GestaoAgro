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

        public SaudeController(AppDbContext context)
        {
            _context = context;
        }

        // GET all Saúde records
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaSaude = await _context.Saude.Include(s => s.Animal).ToListAsync();
                return Ok(listaSaude);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // GET Saúde by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var saude = await _context.Saude.Include(s => s.Animal)
                                                 .FirstOrDefaultAsync(s => s.Id == id);

                if (saude == null)
                {
                    return NotFound($"Saúde # {id} não encontrada");
                }

                return Ok(saude);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // POST create new Saúde record
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SaudeModel item)
        {
            try
            {
                var saude = new SaudeModel
                {
                    Veterinario = item.Veterinario,
                    Status = item.Status,
                    Apetite = item.Apetite,
                    Temperatura = item.Temperatura,
                    CodigoBrinco = item.CodigoBrinco,
                    DataVerificacao = item.DataVerificacao
                };

                await _context.Saude.AddAsync(saude);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = saude.Id }, saude);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // PUT update Saúde by ID
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SaudeModel item)
        {
            try
            {
                var saude = await _context.Saude.FindAsync(id);

                if (saude == null)
                {
                    return NotFound($"Saúde # {id} não encontrada");
                }

                saude.Veterinario = item.Veterinario;
                saude.Status = item.Status;
                saude.Apetite = item.Apetite;
                saude.Temperatura = item.Temperatura;
                saude.CodigoBrinco = item.CodigoBrinco;
                saude.DataVerificacao = item.DataVerificacao;

                _context.Saude.Update(saude);
                await _context.SaveChangesAsync();

                return Ok(saude);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // DELETE Saúde by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var saude = await _context.Saude.FindAsync(id);

                if (saude == null)
                {
                    return NotFound($"Saúde # {id} não encontrada");
                }

                _context.Saude.Remove(saude);
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
