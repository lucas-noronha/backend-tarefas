using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Domain.Entities;
using Tarefas.Domain.Interfaces.Repositorios;

namespace Tarefas.Domain.Interfaces.Repositorios
{
    public interface IClienteRepositorio : IRepositorioPadrao<Cliente>
    {
        IQueryable<Cliente> ObterPorEndereco(string uf, string cidade, string? cep = null, string? bairro = null, string? logradouro = null, string? numero = null);

    }
}
