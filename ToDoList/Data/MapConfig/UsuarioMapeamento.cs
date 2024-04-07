using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Models;

namespace ToDoList.Data.MapConfig
{
    public class UsuarioMapeamento : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome).IsRequired();

            builder.Property(u => u.Email).IsRequired();
            builder.HasIndex(u => u.Email).IsUnique();
            

            builder.Property(u => u.Senha).IsRequired();

            builder.Property(u => u.DDD).IsRequired();

            builder.Property(u => u.NumeroCelular).IsRequired();

            builder.Property(u => u.Ativo).IsRequired();

            builder
                .HasMany(u => u.Tarefas)
                .WithOne()
                .HasForeignKey(t => t.UsuarioId);




        }
    }
}
