using GestaoAgro.DataContexts;
using GestaoAgro.Dtos;
using GestaoAgro.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoAgro.Controllers
{
    [Authorize]
    [ApiController] // Define a classe como um controlador API, com base no atributo ApiController
    [Route("animal")]
    // Define a rota padrão para os endpoints desta API
    public class AnimalController : ControllerBase
    {        
        private readonly AppDbContext _context; // Injeção de dependência do contexto do banco de dados    
        
        public AnimalController(AppDbContext context) // Construtor que recebe o contexto do banco de dados
        {
            _context = context; // Inicializa o contexto do banco
        }

        // Método para obter todos os animais
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                // Recupera todos os animais com alguns campos específicos
                var listaAnimais = await _context.Animal
                    .Select(a => new
                    {
                        a.CodigoBrinco,
                        a.Raca,
                        a.Peso,
                        a.Sexo,
                        a.Idade
                    })
                    .ToListAsync(); // Executa a consulta assíncrona

                // Retorna a lista de animais ou erro caso a lista esteja vazia
                if (!listaAnimais.Any())
                {
                    return NotFound("Nenhum animal encontrado.");
                }

                return Ok(listaAnimais); // Retorna os animais encontrados
            }
            catch (Exception e)
            {
                return Problem($"Erro ao tentar buscar os animais: {e.Message}"); // Retorna erro em caso de falha
            }
        }

        // Método para obter um animal pelo ID (CodigoBrinco)

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                // Busca o animal pelo código do brinco (ID)
                var animal = await _context.Animal
                    .Where(a => a.CodigoBrinco == id)
                    .FirstOrDefaultAsync();

                // Retorna erro se o animal não for encontrado
                if (animal == null)
                {
                    return NotFound($"Animal #{id} não encontrado");
                }

                return Ok(animal); // Retorna o animal encontrado
            }
            catch (Exception e)
            {
                return Problem($"Erro ao tentar buscar o animal #{id}: {e.Message}"); // Retorna erro em caso de falha
            }
        }

        // Método para criar um novo animal
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AnimalDtos item)
        {
            try
            {
                // Verifica se os dados recebidos são inválidos
                if (item == null)
                {
                    return BadRequest("Dados do animal inválidos.");
                }

                // Cria o novo animal com os dados fornecidos
                var animal = new AnimalModel
                {
                    CodigoBrinco = item.CodigoBrinco,
                    Raca = item.Raca,
                    Peso = item.Peso,
                    Sexo = item.Sexo,
                    Idade = item.Idade
                };

                // Adiciona o animal ao banco e salva as mudanças
                await _context.Animal.AddAsync(animal);
                await _context.SaveChangesAsync();

                // Retorna uma resposta com status 201 (Criado) e a URL do novo animal
                return CreatedAtAction(nameof(GetById), new { id = animal.CodigoBrinco }, animal);
            }
            catch (Exception e)
            {
                return Problem($"Erro ao tentar criar o animal: {e.Message}"); // Retorna erro em caso de falha
            }
        }

        // Método para atualizar um animal existente
        [HttpPut("{CodigoBrinco}")]
        public async Task<IActionResult> Put(string CodigoBrinco, [FromBody] AnimalDtos item)
        {
            try
            {
                // Encontra o animal pelo código do brinco (ID)
                var animal = await _context.Animal.FindAsync(CodigoBrinco);

                // Retorna erro se o animal não for encontrado
                if (animal == null)
                {
                    return NotFound($"Animal #{CodigoBrinco} não encontrado.");
                }

                // Atualiza as propriedades do animal
                animal.Raca = item.Raca;
                animal.Peso = item.Peso;
                animal.Sexo = item.Sexo;
                animal.Idade = item.Idade;

                // Atualiza o animal no banco de dados
                _context.Animal.Update(animal);
                await _context.SaveChangesAsync();

                return Ok(animal); // Retorna o animal atualizado
            }
            catch (Exception e)
            {
                return Problem($"Erro ao tentar atualizar o animal #{CodigoBrinco}: {e.Message}"); // Retorna erro em caso de falha
            }
        }

        // Método para remover um animal pelo ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                // Encontra o animal pelo código do brinco (ID)
                var animal = await _context.Animal.FindAsync(id);

                // Retorna erro se o animal não for encontrado
                if (animal == null)
                {
                    return NotFound($"Animal #{id} não encontrado.");
                }

                // Remove o animal do banco de dados
                _context.Animal.Remove(animal);
                await _context.SaveChangesAsync();

                return Ok($"Animal #{id} removido com sucesso."); // Retorna sucesso na remoção
            }
            catch (DbUpdateException dbEx)
            {
                // Retorna erro em caso de falha ao atualizar o banco de dados
                return Problem($"Erro ao tentar remover o animal #{id}: {dbEx.InnerException?.Message ?? dbEx.Message}");
            }
            catch (Exception ex)
            {
                // Retorna erro inesperado
                return Problem($"Erro inesperado ao tentar remover o animal #{id}: {ex.Message}");
            }
        }
    }
}