using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Domain.Entities;

namespace Tarefas.Data.EntitiesMapping
{
    public class HistoricoChamadoMapper : IEntityTypeConfiguration<HistoricoChamado>
    {
        public void Configure(EntityTypeBuilder<HistoricoChamado> builder)
        {
            builder
                .ToTable("historicos_chamados");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("id");

            builder
                .Property(x => x.Anotacao)
                .HasColumnName("anotacao");

            builder
                .Property(x => x.DataOcorrencia)
                .HasColumnName("data_ocorrencia");

            builder
                .Property(x => x.UsuarioId)
                .HasColumnName("id_usuario");

            builder
                .Property(x => x.ChamadoId)
                .HasColumnName("id_chamado");                
        }
    }
}
