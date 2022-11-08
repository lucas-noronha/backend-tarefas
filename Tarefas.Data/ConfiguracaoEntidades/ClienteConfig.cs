using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Domain.Entidades;

namespace Tarefas.Data.ConfiguracaoEntidades
{
    
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder
                .ToTable("clientes");
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("id");

            builder
                .Property(x => x.Nome)
                .HasColumnName("nome");

            builder
                .Property(x => x.UF)
                .HasColumnName("uf")
                .HasMaxLength(2);

            builder
                .Property(x => x.Cidade)
                .HasColumnName("cidade");

            builder
                .Property(x => x.Cep)
                .HasColumnName("cep");

            builder
                .Property(x => x.Bairro)
                .HasColumnName("bairro");

            builder
                .Property(x => x.Logradouro)
                .HasColumnName("logradouro");

            builder
                .Property(x => x.Numero)
                .HasColumnName("numero");

            builder
                .Property(x => x.DataCriacao)
                .HasColumnName("data_criacao");

            builder
                .Property(x => x.Inativo)
                .HasColumnName("inativo");
        }
    }
}
