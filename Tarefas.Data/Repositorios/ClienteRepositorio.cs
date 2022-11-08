using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Domain.Entidades;
using Tarefas.Domain.Interfaces.Repositorios;

namespace Tarefas.Data.Repositorios
{
    public class ClienteRepositorio : RepositorioPadrao<Cliente>, IClienteRepositorio
    {
        public TarefasDb DataContext { get; }

        public ClienteRepositorio(TarefasDb DataContext) : base(DataContext)
        {
            this.DataContext = DataContext;
        }
        public IQueryable<Cliente> ObterPorEndereco(string uf, string cidade, string? cep = null, string? bairro = null, string? logradouro = null, string? numero = null)
        {
            var cliente = DataContext.Clientes.Where(x => x.UF == uf && x.Cidade == cidade);

            if (!string.IsNullOrWhiteSpace(cep))
            {
                cliente = cliente.Where(x => x.Cep == cep);
            }
            if (!string.IsNullOrWhiteSpace(bairro))
            {
                cliente = cliente.Where(x => x.Bairro == bairro);
            }
            if (!string.IsNullOrWhiteSpace(logradouro))
            {
                cliente = cliente.Where(x => x.Logradouro == logradouro);
            }
            if (!string.IsNullOrWhiteSpace(numero))
            {
                cliente = cliente.Where(x => x.Numero == numero);
            }

            return cliente;
        }
        public override IQueryable<Cliente> ListaComVinculos()
        {
            var clientes = DataContext.Clientes;

            return clientes;
        }
        public override IQueryable<Cliente> ObterPorDataCriacao(DateTime date)
        {
            return DataContext.Clientes.Where(x => x.DataCriacao == date);
        }

    }
}
