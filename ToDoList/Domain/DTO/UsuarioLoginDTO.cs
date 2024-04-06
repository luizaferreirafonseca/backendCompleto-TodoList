using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.DTO
{
    public class UsuarioLoginDTO
    {

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
