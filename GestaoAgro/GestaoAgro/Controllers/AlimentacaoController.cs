using GestaoAgro.DataContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoAgro.Controllers
{
    [ApiController]
    [Route("Alimentacao")]
    public class AlimentacaoController : Controller
    {
        private readonly AppDbContext _context;
        public AlimentacaoController(AppDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaAlimentacao = await _context.Alimentacao.ToListAsync();
                return Ok(listaAlimentacao);
            }

            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
