using GestaoAgro.DataContexts;
using GestaoAgro.Dtos;
using GestaoAgro.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoAgro.Controllers
{

    [ApiController]
    [Route("Producao")]
    public class ProducaoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProducaoController(AppDbContext context)
        {
            _context = context;
        }

        // GET all producoes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaProducao = await _context.Producao
                    .Include(p => p.Animal)  // Incluir informações sobre o Animal
                    .Select(p => new
                    {
                        p.Id,
                        p.TipoProducao,
                        p.Data,
                        p.QuantidadeProduzida,
                        Animal = new
                        {
                            CodigoBrinco = p.Animal.CodigoBrinco, // Acesso correto à propriedade do Animal
                            p.Animal.Raca
                        }
                    })
                    .ToListAsync();

                return Ok(listaProducao);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // GET producao by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var producao = await _context.Producao
                    .Include(p => p.Animal)  // Incluir informações sobre o Animal
                    .Where(p => p.Id == id)
                    .FirstOrDefaultAsync();

                if (producao == null)
                {
                    return NotFound($"Producao #{id} não encontrada");
                }

                return Ok(producao);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // POST create new producao
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProducaoModel item)
        {
            try
            {
                var producao = new ProducaoModel
                {
                    TipoProducao = item.TipoProducao,
                    Data = item.Data,
                    QuantidadeProduzida = item.QuantidadeProduzida,
                    CodigoBrinco = item.CodigoBrinco // Relacionamento com o Animal
                };

                await _context.Producao.AddAsync(producao);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = producao.Id }, producao);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // PUT update producao by ID
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProducaoModel item)
        {
            try
            {
                var producao = await _context.Producao.FindAsync(id);

                if (producao is null)
                {
                    return NotFound();
                }

                producao.TipoProducao = item.TipoProducao;
                producao.Data = item.Data;
                producao.QuantidadeProduzida = item.QuantidadeProduzida;
                producao.CodigoBrinco = item.CodigoBrinco;

                _context.Producao.Update(producao);
                await _context.SaveChangesAsync();

                return Ok(producao);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // DELETE producao by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var producao = await _context.Producao.FindAsync(id);

                if (producao is null)
                {
                    return NotFound();
                }

                _context.Producao.Remove(producao);
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
