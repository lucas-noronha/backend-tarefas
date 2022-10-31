﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Domain.Entities;

namespace Tarefas.Domain.Interfaces.Repositorios
{
    public interface IRepositorioPadrao<T> where T : class
    {
        T ObterPorId(Guid id);
        IQueryable<T> ObterPorDataCriacao(DateTime date);
        IQueryable<T> ObterLista();
        IQueryable<T> ListaComVinculos();
        bool Adicionar(T entidade);
        void Alterar(T entidade);
        void Deletar(T entidade);
    }
}
