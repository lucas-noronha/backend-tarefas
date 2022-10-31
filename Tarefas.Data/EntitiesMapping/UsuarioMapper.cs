using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Domain.Entities;

namespace Tarefas.Data.EntitiesMapping
{
    public class UsuarioMapper : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .ToTable("usuarios");
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("id");

            builder
                .Property(x => x.Nome)
                .HasColumnName("nome");

            builder
                .Property(x => x.TipoUsuario)
                .HasColumnName("tipo_usuario");

            builder
                .Property(x => x.Login)
                .HasColumnName("login");
            
            builder
                .Property(x => x.Senha)
                .HasColumnName("senha");
            
            builder
                .Property(x => x.DataCriacao)
                .HasColumnName("data_criacao");

            builder
                .HasMany(x => x.Tarefas)
                .WithOne(x => x.Responsavel);
        }
    }
}
