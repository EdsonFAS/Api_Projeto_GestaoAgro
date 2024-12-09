using GestaoAgro.DataContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoAgro.Controllers
{
    [ApiController]
    [Route("Producao")]
    public class ProducaoController : Controller
    {
        private readonly AppDbContext _context;
        public ProducaoController(AppDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducao()
        {
            try
            {
                var listarProducao = await _context.Producao.ToArrayAsync();
                return Ok(listarProducao);
            }

            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
