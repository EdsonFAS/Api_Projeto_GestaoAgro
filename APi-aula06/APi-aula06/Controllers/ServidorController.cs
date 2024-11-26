using APi_aula06.DataContexts;
using APi_aula06.Dtos;
using APi_aula06.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APi_aula06.Controllers
{       
        [ApiController]
        [Route("Servidores")]
    public class ServidorController : Controller
    {
        private readonly AppDContexts _context;

        public ServidorController(AppDContexts context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {

            try
            {
                var listaServidores = await _context.Servidores.ToListAsync();
                return Ok(listaServidores);
            }
            catch (Exception e) {
                return Problem(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {

            try
            {
                var servidor = await _context.Servidores.Where(servidor => servidor.id == id).FirstOrDefaultAsync();
             
                if (servidor == null)
                {
                    return NotFound($"Servidor com ${id} não encontrado");
                } 
                return Ok(servidor);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
            
        }

        [HttpPost]
        public async Task< IActionResult> Post([FromBody] ServidorSiape item)
        {

            try
            {
                var servidor = new ServidorModel()
                {
                    name = item.name,
                    cpf = item.cpf,
                    siape = item.siape,
                };
                await _context.Servidores.AddAsync(servidor);
                await _context.SaveChangesAsync();
                return Created("",servidor);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ServidorSiape item) {

            try
            {
                var servidor = await _context.Servidores.FindAsync(id);
                if (servidor == null) { 
                return NotFound("Servidor não encontrado");
                }

                servidor.name = item.name;
                servidor.cpf = item.cpf;
                servidor.siape = item.siape;

               _context.Servidores.Update(servidor);
                await _context.SaveChangesAsync();
                return Ok(servidor);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> Delete(int id) {
            try
            {
                var servidor = await _context.Servidores.FindAsync(id);
                if (servidor == null) {
                    NotFound("Servidor não encontrado");
                }

                _context.Servidores.Remove(servidor);
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
