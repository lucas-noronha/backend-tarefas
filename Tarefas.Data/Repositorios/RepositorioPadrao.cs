using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Domain.Entities;
using Tarefas.Domain.Interfaces.Repositorios;

namespace Tarefas.Data.Repositorios
{
    public abstract class RepositorioPadrao<T> : IRepositorioPadrao<T> where T : class 
    {
        public TarefasDb DataContext { get; }

        public RepositorioPadrao(TarefasDb dataContext)
        {
            DataContext = dataContext;
        }
        public T ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }
        public IQueryable<T> ObterLista()
        {
            return DataContext.Set<T>();
        }

        public bool Adicionar(T entidade)
        {
            DataContext.Set<T>().Add(entidade);
            DataContext.SaveChanges();

            return true;
        }

        public bool AdicionarLista(ICollection<T> entidades)
        {
            DataContext.Set<T>().AddRange(entidades);
            DataContext.SaveChanges();

            return true;
        }

        public void Alterar(T entidade)
        {
            DataContext.Entry(entidade).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            DataContext.SaveChanges();
        }

        public void Deletar(T entidade)
        {
            DataContext.Set<T>().Remove(entidade);
            DataContext.SaveChanges();
        }

        public abstract IQueryable<T> ObterPorDataCriacao(DateTime date);
        public abstract IQueryable<T> ListaComVinculos();
    }
}
