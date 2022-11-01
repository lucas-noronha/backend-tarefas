using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Domain.Entities;

namespace Tarefas.Domain.Interfaces.Repositorios
{
    public interface IChamadoRepositorio : IRepositorioPadrao<Chamado>
    {
        IQueryable<Chamado> ObterPorCliente(Guid clienteId);

        IQueryable<Chamado> ObterPorResponsavel(Guid responsavelId);

        void AdicionarHistorico(HistoricoChamado historicoChamado);

        void AdicionarTempoGasto(TempoGasto tempoGasto);

        void RemoverHistorico(Guid historicoId);

        void RemoverTempoGasto(Guid tempoId);
    }
}
