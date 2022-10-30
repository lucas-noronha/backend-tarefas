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
    public class TempoGastoMapper : IEntityTypeConfiguration<TempoGasto>
    {
        public void Configure(EntityTypeBuilder<TempoGasto> builder)
        {
            builder
                .ToTable("tempo_gasto");
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("id");

            builder
                .Property(x => x.Atividade)
                .HasColumnName("atividade");

            builder
                .Property(x => x.Tempo)
                .HasColumnName("tempo_gasto");

            builder
                .Property(x => x.DataAtividade)
                .HasColumnName("data_criacao");

            builder
                .Property(x => x.ChamadoId)
                .HasColumnName("id_chamado");
        }
    }
}
