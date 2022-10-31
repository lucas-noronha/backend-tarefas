using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarefas.Domain.Entities
{
    public class TempoGasto
    {
        public TempoGasto()
        {

        }
        public TempoGasto(TimeSpan tempo, string atividade, DateTime dataAtividade, Chamado chamado)
        {
            Id = Guid.NewGuid();

            Tempo = tempo;
            Atividade = atividade;
            DataAtividade = dataAtividade;

            ChamadoId = chamado.Id;
            Chamado = chamado;
        }
        public Guid Id { get; set; }
        public TimeSpan Tempo { get; set; }
        public string Atividade { get; set; }
        public DateTime DataAtividade { get; set; }
        public Guid ChamadoId { get; set; }
        public Chamado Chamado { get; set; }


    }
}
