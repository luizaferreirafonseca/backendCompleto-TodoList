using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.Models
{
    public class Tarefa
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string NomeTarefa { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public DateTime DataTermino { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; } = null!; 

        public Tarefa()
        {

        }

   

    }
}
