using GestaoAgro.DataContexts;
using GestaoAgro.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoAgro.Controllers
{

    [ApiController]
    [Route("Rebanho")]
    public class RebanhoController : ControllerBase
    {
        private readonly AppDbContext _context;

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
                var listaRebanho = await _context.Rebanho
                    .Include(p => p.Animal)  // Incluir informações do Animal
                    .Select(p => new
                    {
                        p.Id,
                        p.Tipo,
                        p.Destino,
                        Animal = new
                        {
                            CodigoBrinco = p.Animal.CodigoBrinco, // Acesso correto à propriedade Animal
                            p.Animal.Raca
                        }
                    })
                    .ToListAsync();

                return Ok(listaRebanho);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // GET Rebanho by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var rebanho = await _context.Rebanho
                    .Include(p => p.Animal)
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();

                if (rebanho == null)
                {
                    return NotFound($"Rebanho #{id} não encontrado");
                }

                return Ok(rebanho);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // POST create new Rebanho
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RebanhoModel item)
        {
            try
            {
                var rebanho = new RebanhoModel
                {
                    Tipo = item.Tipo,
                    Destino = item.Destino,
                    CodigoBrinco = item.CodigoBrinco // Relacionamento com o Animal
                };

                await _context.Rebanho.AddAsync(rebanho);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = rebanho.Id }, rebanho);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // PUT update Rebanho by ID
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RebanhoModel item)
        {
            try
            {
                var rebanho = await _context.Rebanho.FindAsync(id);

                if (rebanho == null)
                {
                    return NotFound($"Rebanho #{id} não encontrado");
                }

                rebanho.Tipo = item.Tipo;
                rebanho.Destino = item.Destino;
                rebanho.CodigoBrinco = item.CodigoBrinco;

                _context.Rebanho.Update(rebanho);
                await _context.SaveChangesAsync();

                return Ok(rebanho);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // DELETE Rebanho by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var rebanho = await _context.Rebanho.FindAsync(id);

                if (rebanho == null)
                {
                    return NotFound($"Rebanho #{id} não encontrado");
                }

                _context.Rebanho.Remove(rebanho);
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
