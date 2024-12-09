using GestaoAgro.DataContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoAgro.Controllers
{
    [ApiController]
    [Route("Rebanho")]
    public class RebanhoController : Controller
    {
        private readonly AppDbContext _context;
        public RebanhoController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetRebanho()
        {
            try
            {
                var listarRebanho = await _context.Rebanho.ToArrayAsync();

                return Ok(listarRebanho);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
