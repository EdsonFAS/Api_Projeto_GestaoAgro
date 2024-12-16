using GestaoAgro.DataContexts;
using GestaoAgro.Dtos;
using GestaoAgro.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoAgro.Controllers
{

    [ApiController]
    [Route("Animal")]
    public class AnimalController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AnimalController(AppDbContext context)
        {
            _context = context;
        }

        // GET all animais
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaAnimais = await _context.Animal
                    .Select(a => new
                    {
                        a.CodigoBrinco,
                        a.Raca,
                        a.Peso,
                        a.Sexo,
                        a.Idade
                    })
                    .ToListAsync();

                return Ok(listaAnimais);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // GET animal by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var animal = await _context.Animal
                    .Where(a => a.CodigoBrinco == id)
                    .FirstOrDefaultAsync();

                if (animal == null)
                {
                    return NotFound($"Animal #{id} não encontrado");
                }

                return Ok(animal);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // POST create new animal
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AnimalDtos item)
        {
            try
            {
                var animal = new AnimalModel
                {
                    Raca = item.Raca,
                    Peso = item.Peso,
                    Sexo = item.Sexo,
                    Idade = item.Idade
                };

                await _context.Animal.AddAsync(animal);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = animal.CodigoBrinco }, animal);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // PUT update animal by ID
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AnimalDtos item)
        {
            try
            {
                var animal = await _context.Animal.FindAsync(id);

                if (animal is null)
                {
                    return NotFound();
                }

                animal.Raca = item.Raca;
                animal.Peso = item.Peso;
                animal.Sexo = item.Sexo;
                animal.Idade = item.Idade;

                _context.Animal.Update(animal);
                await _context.SaveChangesAsync();

                return Ok(animal);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // DELETE animal by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var animal = await _context.Animal.FindAsync(id);

                if (animal is null)
                {
                    return NotFound();
                }

                _context.Animal.Remove(animal);
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
