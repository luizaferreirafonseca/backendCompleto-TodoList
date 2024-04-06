using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        public int DDD {  get; set; }

        public int NumeroCelular { get; set; }

        public bool Ativo { get; set; } = true; 

        public List<Tarefa>? Tarefas { get; set; }




        public Usuario()
        {

        }

        

    }


    
}
