using GestaoAgro.DataContexts;
using GestaoAgro.Dtos;
using GestaoAgro.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoAgro.Controladores
{
    [ApiController]
    [Route("Pastagem")]
    public class PastagemController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PastagemController(AppDbContext context)
        {
            _context = context;
        }

        // OBTER todos os pastágenos
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaPastagem = await _context.Pastagem
                    .Include(p => p.Animal) // Incluir informações sobre o Animal
                    .Select(p => new
                    {
                        p.Id,
                        p.AreaPastagem,
                        p.LocalizacaoPastagem,
                        p.Periodo,
                        Animal = new
                        {
                            CodigoBrinco = p.Animal.CodigoBrinco, // Acesso correto à propriedade do Animal
                            p.Animal.Raca
                        }
                    })
                    .ToListAsync();

                return Ok(listaPastagem);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // GET pastagem por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var pastagem = await _context.Pastagem
                    .Include(p => p.Animal) // Incluir informações sobre o Animal
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();

                if (pastagem == null)
                {
                    return NotFound($"Pastagem #{id} não encontrada");
                }

                return Ok(pastagem);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // POST criar nova pastagem
        [HttpPost]
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

                await _context.Pastagem.AddAsync(pastagem);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = pastagem.Id }, pastagem);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // PUT atualização pastagem por ID
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PastagemModel item)
        {
            try
            {
                var pastagem = await _context.Pastagem.FindAsync(id);

                if (pastagem == null)
                {
                    return NotFound();
                }

                pastagem.AreaPastagem = item.AreaPastagem;
                pastagem.LocalizacaoPastagem = item.LocalizacaoPastagem;
                pastagem.Periodo = item.Periodo;
                pastagem.CodigoBrinco = item.CodigoBrinco;

                _context.Pastagem.Update(pastagem);
                await _context.SaveChangesAsync();

                return Ok(pastagem);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // DELETE pastagem por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var pastagem = await _context.Pastagem.FindAsync(id);

                if (pastagem == null)
                {
                    return NotFound();
                }

                _context.Pastagem.Remove(pastagem);
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
