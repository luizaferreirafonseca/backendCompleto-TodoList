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

        [HttpPost]

        public ActionResult CriarUsuario([FromBody]CriarUsuarioDTO criarUsuarioDTO)
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


    }
}
