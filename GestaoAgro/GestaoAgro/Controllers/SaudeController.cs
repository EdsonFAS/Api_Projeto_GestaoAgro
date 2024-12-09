using GestaoAgro.DataContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoAgro.Controllers
{
    [ApiController]
    [Route("Saude")]
    public class SaudeController : Controller
    {
        private readonly AppDbContext _context;
        public SaudeController(AppDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetSaude()
        {
            try
            {
                var listarSaude = await _context.Saude.ToArrayAsync();
                return Ok(listarSaude);
            }

            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
