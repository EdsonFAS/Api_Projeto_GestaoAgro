using GestaoAgro.DataContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoAgro.Controllers
{
    [ApiController]
    [Route("RebanhoAlimentacao")]
    public class RebanhoAlimentacaoController : Controller
    {
        private readonly AppDbContext _context;
        public RebanhoAlimentacaoController(AppDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetRebanhoAlimentacaoC()
        {
            try
            {
                var listarRebanhoAlimentacaoC = await _context.RebanhoAlimentacao.ToArrayAsync();
                return Ok(listarRebanhoAlimentacaoC);
            }

            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
