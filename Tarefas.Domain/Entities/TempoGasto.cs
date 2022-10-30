using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarefas.Domain.Entities
{
    internal class TempoGasto
    {
        internal TempoGasto(TimeSpan tempo, string atividade, DateTime dataAtividade)
        {
            Id = Guid.NewGuid();

            Tempo = tempo;
            Atividade = atividade;
            DataAtividade = dataAtividade;
        }
        protected Guid Id { get; set; }

        protected TimeSpan Tempo { get; set; }

        protected string Atividade { get; set; }

        protected DateTime DataAtividade { get; set; }
    }
}
