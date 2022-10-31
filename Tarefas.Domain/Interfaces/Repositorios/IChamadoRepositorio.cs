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
    }
}
