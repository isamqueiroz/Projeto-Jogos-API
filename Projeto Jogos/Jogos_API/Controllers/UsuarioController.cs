using Jogos_API.Domains;
using Jogos_API.Interface;
using Jogos_API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Jogos_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : Controller
    {
        private readonly IUsuariosRepository _usuarioRepository;
        public UsuarioController(IUsuariosRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201, usuario);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        // Listar Usuário
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Usuario> listaDeUsuario = _usuarioRepository.Listar();

                return Ok(listaDeUsuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Atualizar Usuário
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Usuario usuario)
        {
            try
            {
                _usuarioRepository.Atualizar(id, usuario);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // Deletar Jogo
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _usuarioRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
