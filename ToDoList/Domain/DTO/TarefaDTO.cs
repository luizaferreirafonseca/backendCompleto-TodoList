using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.DTO
{
    public class TarefaDTO
    {
        [Required]
        public string NomeTarefa { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public DateTime DataTermino { get; set; }

        [Required]
        public string Descricao { get; set; }

        public int? UsuarioId { get; set; }
    }
}
