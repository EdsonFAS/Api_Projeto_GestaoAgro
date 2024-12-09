using GestaoAgro.DataContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoAgro.Controllers
{
    [ApiController]
    [Route("Pastagem")]
    public class PastagemController : Controller
    {
        private readonly AppDbContext _context;
        public PastagemController(AppDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public async Task<ActionResult> GetPastagem()
        {
            try
            {
                var listarPastagem = await _context.Pastagem.ToArrayAsync();
                return Ok(listarPastagem);
            }

            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

    }
}
