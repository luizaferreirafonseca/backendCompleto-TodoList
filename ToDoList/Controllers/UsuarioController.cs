using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTO;
using ToDoList.Domain.Services;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        private readonly LoginService _loginService;

        public UsuarioController(UsuarioService usuarioService, LoginService loginService)
        {
            _usuarioService = usuarioService;
            _loginService = loginService;
        }

        [HttpPost("Cadastrar")]

        public ActionResult CadastrarUsuario([FromBody]CriarUsuarioDTO criarUsuarioDTO)
        {
            try
            {
                 _usuarioService.Cadastrar(criarUsuarioDTO);
                return Ok(new
                {
                    Message = "Usuário cadastrado com sucesso!"
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


        [HttpPost("Login")]
        public ActionResult Login([FromBody] UsuarioLoginDTO loginDto)
        {
            if (loginDto == null)
            {
                return BadRequest("Não foi possível completar o login");
            }

            var usuario = _loginService.Login(loginDto);

            if (usuario == null)
            {
                return Unauthorized("Credenciais inválidas");
            }

            usuario.Senha = null;

            return Ok(usuario); 

        }


        [HttpGet("{id}")]
        public ActionResult PegarUsuarioPeloId(int id)
        {
            var usuario = _usuarioService.PegarPeloId(id);
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado");
            }

            usuario.Senha = null;
            return Ok(usuario);
        }

        [HttpDelete("Deletar")]

        public ActionResult Deletar(int id)
        {
            bool deletado = _usuarioService.Deletar(id);
            
            if (!deletado)
            {
                return NotFound("Usuário não encontrado");
            }
            return Ok("Usuário deletado com sucesso");
        }

        [HttpGet()]

        public ActionResult PegarPeloEmail(string email)
        {
            var usuario = _usuarioService.PegarPorEmail(email);
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado");
            }
            usuario.Senha = null;
            return Ok(usuario);
        }

        [HttpGet("PegarUsuarios")]
        public ActionResult PegarUsuarios()
        {
            var usuarios = _usuarioService.PegarUsuarios();
            return Ok(usuarios);
        }


    }
}
