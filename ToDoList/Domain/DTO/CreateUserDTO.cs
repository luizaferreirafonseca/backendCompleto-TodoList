using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.DTO
{
    public class CreateUserDTO
    {

        [Required(ErrorMessage = "Nome não informado.")]
        [MinLength(3, ErrorMessage = "Nome deve ter pelo menos 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; } = null!;

        [Required]
        [EmailAddress(ErrorMessage = "O endereço de Email precisa ser um email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha não informada.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "DDD não informado.")]
        [Range(11, 99, ErrorMessage = "DDD Precisa ter 2 digítos.")]
        public int DDD { get; set; }

        [Required(ErrorMessage = "Número de telefone não informado.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Número de telefone deve possuir apenas números.")]

        public int NumeroCelular { get; set; }

        public bool Ativo { get; set; } = true;



    }
}
