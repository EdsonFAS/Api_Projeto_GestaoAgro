using GestaoAgro.DataContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestaoAgro.Dtos;
using GestaoAgro.Model;

namespace GestaoAgro.Controllers
{

    [ApiController]
    [Route("Usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        // GET all usuarios
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaUsuario = await _context.Usuario
                    .Select(u => new {
                        u.Id,
                        u.NomeCompleto,
                        u.NomeUsuario,
                        u.Email,
                        u.CPF,
                        u.DataNascimento,
                        u.Endereco
                    })
                    .ToListAsync();

                return Ok(listaUsuario);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // GET usuario by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var usuario = await _context.Usuario
                    .Where(u => u.Id == id)
                    .FirstOrDefaultAsync();

                if (usuario == null)
                {
                    return NotFound($"Usuário #{id} não encontrado");
                }

                return Ok(usuario);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // POST create new usuario
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioDtos item)
        {
            try
            {
                var usuario = new UsuarioModel
                {
                    NomeCompleto = item.NomeCompleto,
                    NomeUsuario = item.NomeUsuario,
                    Senha = item.Senha,
                    Email = item.Email,
                    CPF = item.CPF,
                    DataNascimento = (DateTime)item.DataNascimento,
                    Endereco = item.Endereco
                };

                await _context.Usuario.AddAsync(usuario);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // PUT update usuario by ID
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UsuarioDtos item)
        {
            try
            {
                var usuario = await _context.Usuario.FindAsync(id);

                if (usuario is null)
                {
                    return NotFound();
                }

                usuario.NomeCompleto = item.NomeCompleto;
                usuario.NomeUsuario = item.NomeUsuario;
                usuario.Senha = item.Senha;
                usuario.Email = item.Email;
                usuario.CPF = item.CPF;
                usuario.DataNascimento = (DateTime)item.DataNascimento;
                usuario.Endereco = item.Endereco;

                _context.Usuario.Update(usuario);
                await _context.SaveChangesAsync();

                return Ok(usuario);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // DELETE usuario by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var usuario = await _context.Usuario.FindAsync(id);

                if (usuario is null)
                {
                    return NotFound();
                }

                _context.Usuario.Remove(usuario);
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
