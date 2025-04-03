using Azure;
using Jogos_API.Domains;
using Jogos_API.Interface;
using Jogos_API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Jogos_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class JogoController : ControllerBase
    {
        private readonly IJogosRepository _jogosRepository;
        public JogoController(IJogosRepository jogosRepository)
        {
            _jogosRepository = jogosRepository;
        }

        // Cadastrar
        [HttpPost]
        public IActionResult Post(Jogo novoJogo)
        {
            try
            {
                _jogosRepository.Cadastrar(novoJogo);

                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Listar
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Jogo> listaDeJogo = _jogosRepository.Listar();

                return Ok(_jogosRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Atualizar
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Jogo jogo)
        {
            try
            {
                _jogosRepository.Atualizar(id, jogo);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Deletar
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _jogosRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
