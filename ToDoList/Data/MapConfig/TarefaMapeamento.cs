using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Models;

namespace ToDoList.Data.MapConfig
{
    public class TarefaMapeamento : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tarefas");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.NomeTarefa).IsRequired();

            builder.Property(t => t.DataInicio).IsRequired();

            builder.Property(t => t.DataTermino).IsRequired();

            builder.Property(t => t.Descricao).IsRequired();

            builder.HasOne(t => t.Usuario)
               .WithMany(u => u.Tarefas) 
               .HasForeignKey(t => t.UsuarioId) 
               .IsRequired();
        }
    }
}
