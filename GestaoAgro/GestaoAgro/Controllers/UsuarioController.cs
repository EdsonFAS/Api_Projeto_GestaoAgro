using GestaoAgro.DataContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoAgro.Controllers
{
    [ApiController]
    [Route("Usuario")]
    public class UsuarioController : Controller
    {
        private readonly AppDbContexts _context;
        public UsuarioController(AppDbContexts context)
        {
            this._context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsuario()
        {
            try
            {
                var listarUsuario = await _context.Usuario.ToArrayAsync();
                return Ok(listarUsuario);
            }

            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }

}
