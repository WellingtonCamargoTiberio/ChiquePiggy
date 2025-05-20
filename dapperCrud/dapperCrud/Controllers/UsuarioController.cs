using dapperCrud.Dto;
using dapperCrud.Models;
using dapperCrud.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dapperCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioInterface _usuarioInterface;
        public UsuarioController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        [HttpGet]
        public async Task<IActionResult> ListarUsuario()
        {
            var usuarios = await _usuarioInterface.BuscarUsuarios();

            if (usuarios.Status == false)
                return NotFound(usuarios);
            return Ok(usuarios);
        }

        [HttpGet ("{idUsuario}")]
        public async Task<IActionResult> ListarUsuarioPorId(int idUsuario)
        {
            var usuario = await _usuarioInterface.Usuario(idUsuario);

            if (usuario.Status == false)
                return NotFound(usuario);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario(UsuarioCriarDto usuarios)
        {
            var usuarioCriar = await _usuarioInterface.CriarUsuario(usuarios);

            if(usuarioCriar.Status == false)
                return BadRequest(usuarioCriar);
            return Ok(usuarioCriar);
            
        }

        [HttpDelete("{idUsuario}")]

        public async Task<IActionResult> DeletarUsuario (int idUsuario)
        {
            var usuarioCriar = await _usuarioInterface.DeletarUsuario(idUsuario);

            if (usuarioCriar.Status == false)
                return BadRequest(usuarioCriar);
            return Ok(usuarioCriar);
        }

        [HttpPut("{idUsuario}")]

        public async Task<IActionResult> AlterarUsuario(int idUsuario, UsuarioAlterarDto usuario)
        {
            var usuarioAlterar = await _usuarioInterface.AtualizarUsuario(idUsuario, usuario);

            if (usuarioAlterar.Status == false)
                return BadRequest(usuarioAlterar);
            return Ok(usuarioAlterar);
        }
    }
}
