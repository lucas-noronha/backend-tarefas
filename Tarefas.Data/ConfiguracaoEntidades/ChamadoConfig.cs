using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Domain.Entidades;

namespace Tarefas.Data.ConfiguracaoEntidades
{
    public class ChamadoConfig : IEntityTypeConfiguration<Chamado>
    {
        public void Configure(EntityTypeBuilder<Chamado> builder)
        {
            builder
                .ToTable("chamados");
            
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("id");

            builder
                .Property(x => x.Titulo)
                .HasColumnName("titulo");

            builder
                .Property(x => x.Descricao)
                .HasColumnName("descricao");

            builder
                .Property(x => x.DataPrevista)
                .HasColumnName("data_prevista");

            builder
                .Property(x => x.DataCriacao)
                .HasColumnName("data_criacao");

            builder
                .Property(x => x.TipoChamado)
                .HasColumnName("tipo");

            builder
                .Property(x => x.Status)
                .HasColumnName("status");

            builder
                .Property(x => x.CriadorId)
                .HasColumnName("id_criador");

            builder
                .Property(x => x.ResponsavelId)
                .HasColumnName("id_responsavel");

            builder
                .Property(x => x.ClienteId)
                .HasColumnName("id_cliente");


            builder
                .HasMany(x => x.TempoGasto)
                .WithOne(x => x.Chamado);

            builder
                .HasMany(x => x.Historico)
                .WithOne(x => x.Chamado);
        }
    }
}
