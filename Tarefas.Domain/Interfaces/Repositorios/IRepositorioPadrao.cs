using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Domain.Entities;

namespace Tarefas.Domain.Interfaces.Repositorios
{
    public interface IRepositorioPadrao<T>
    {
        T ObterPorId(Guid id);
        IQueryable<Chamado> ObterPorDataCriacao(DateTime date);
        IQueryable<T> Lista();
        IQueryable<T> ListaComVinculos();
        bool Adicionar(T entidade);
        void Alterar(T entidade);
        void Deletar(T entidade);
    }
}
