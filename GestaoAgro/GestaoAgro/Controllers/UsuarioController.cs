using GestaoAgro.DataContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestaoAgro.Dtos;
using GestaoAgro.Model;

namespace GestaoAgro.Controllers
{    
    [ApiController] // Definindo a classe de controle de usuários com a rota base "Usuario"
    [Route("Usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context) // Construtor para injeção de dependência do contexto do banco de dados
        {
            _context = context;
        }
                
        [HttpGet] // Método para retornar todos os usuários
        public async Task<IActionResult> GetAll()
        {
            try
            {
                // Consultando todos os usuários e projetando a resposta
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

                // Retornando a lista de usuários em caso de sucesso
                return Ok(listaUsuario);
            }
            catch (Exception e)
            {
                // Caso ocorra um erro, retornando uma mensagem de erro
                return Problem($"Erro ao tentar buscar todos os usuários: {e.Message}");
            }
        }

        // Método para retornar um usuário por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                // Buscando o usuário pelo ID
                var usuario = await _context.Usuario
                    .Where(u => u.Id == id)
                    .FirstOrDefaultAsync();

                // Verificando se o usuário não foi encontrado
                if (usuario == null)
                {
                    // Retornando uma mensagem de erro caso o usuário não seja encontrado
                    return NotFound($"Usuário #{id} não encontrado.");
                }

                // Retornando o usuário encontrado
                return Ok(usuario);
            }
            catch (Exception e)
            {
                // Retornando erro em caso de exceção
                return Problem($"Erro ao tentar buscar o usuário com ID {id}: {e.Message}");
            }
        }

        // Método para criar um novo usuário
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioDtos item)
        {
            try
            {
                // Criando uma instância de UsuarioModel com os dados recebidos
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

                // Adicionando o usuário ao contexto e salvando as alterações no banco de dados
                await _context.Usuario.AddAsync(usuario);
                await _context.SaveChangesAsync();

                // Retornando sucesso com a URL para acessar o novo usuário criado
                return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
            }
            catch (Exception e)
            {
                // Retornando erro em caso de exceção durante a criação do usuário
                return Problem($"Erro ao tentar criar um novo usuário: {e.Message}");
            }
        }

        // Método para atualizar um usuário por ID
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UsuarioDtos item)
        {
            try
            {
                // Buscando o usuário no banco de dados pelo ID
                var usuario = await _context.Usuario.FindAsync(id);

                // Verificando se o usuário foi encontrado
                if (usuario is null)
                {
                    // Retornando erro caso o usuário não exista
                    return NotFound($"Usuário #{id} não encontrado.");
                }

                // Atualizando os dados do usuário com as informações fornecidas
                usuario.NomeCompleto = item.NomeCompleto;
                usuario.NomeUsuario = item.NomeUsuario;
                usuario.Senha = item.Senha;
                usuario.Email = item.Email;
                usuario.CPF = item.CPF;
                usuario.DataNascimento = (DateTime)item.DataNascimento;
                usuario.Endereco = item.Endereco;

                // Atualizando o usuário no banco de dados
                _context.Usuario.Update(usuario);
                await _context.SaveChangesAsync();

                // Retornando o usuário atualizado com sucesso
                return Ok(usuario);
            }
            catch (Exception e)
            {
                // Retornando erro em caso de exceção durante a atualização
                return Problem($"Erro ao tentar atualizar o usuário com ID {id}: {e.Message}");
            }
        }

        // Método para excluir um usuário por ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                // Buscando o usuário no banco de dados pelo ID
                var usuario = await _context.Usuario.FindAsync(id);

                // Verificando se o usuário existe
                if (usuario is null)
                {
                    // Retornando erro caso o usuário não seja encontrado
                    return NotFound($"Usuário #{id} não encontrado.");
                }

                // Removendo o usuário do banco de dados
                _context.Usuario.Remove(usuario);
                await _context.SaveChangesAsync();

                // Retornando sucesso com status 200 após a exclusão
                return Ok($"Usuário #{id} removido com sucesso.");
            }
            catch (Exception e)
            {
                // Retornando erro em caso de exceção durante a exclusão
                return Problem($"Erro ao tentar excluir o usuário com ID {id}: {e.Message}");
            }
        }
    }
}