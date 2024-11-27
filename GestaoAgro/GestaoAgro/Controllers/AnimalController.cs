using GestaoAgro.DataContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoAgro.Controllers
{
    [ApiController]
    [Route("Animais")]
    public class AnimalController : Controller
    {
        private readonly AppDbContexts _context;
        public AnimalController(AppDbContexts context) { 
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAnimal()
        {
            try {
                var listarAnimais = await _context.Animais.ToListAsync();

                return Ok(listarAnimais);
            }
            catch (Exception ex) 
            {
                return Problem(ex.Message);
            }
        }
        
    }
}
