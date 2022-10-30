using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Domain.Interfaces;

namespace Tarefas.Domain.Entities
{
    internal class Cliente : Pessoa, IEndereco
    {
        internal Cliente(string nome)
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;

            Nome = nome;
        }

        public string Bairro { get => ObterBairro(); set => AtribuirBairro(value); }
        public string Cidade { get => ObterCidade(); set => AtribuirCidade(value); }
        public string UF { get => ObterUF(); set => AtribuirUF(value); }
        public string Logradouro { get => ObterLogradouro(); set => AtribuirLogradouro(value); }
        public string Numero { get => ObterNumero(); set => AtribuirNumero(value); }
        public string Cep { get => ObterCep(); set => AtribuirCep(value); }

        #region AcessadoresEndereco
        internal string ObterBairro()
        {
            return Bairro;
        }
        internal void AtribuirBairro(string bairro)
        {
            Bairro = bairro;
        }
        internal string ObterCidade()
        {
            return Cidade;
        }
        internal void AtribuirCidade(string cidade)
        {
            Cidade = cidade;
        }
        internal string ObterUF()
        {
            return UF;
        }
        internal void AtribuirUF(string uf)
        {
            UF = uf;
        }
        internal string ObterLogradouro()
        {
            return Logradouro;
        }
        internal void AtribuirLogradouro(string logradouro)
        {
            Logradouro = logradouro;
        }
        internal string ObterNumero()
        {
            return Numero;
        }
        internal void AtribuirNumero(string numero)
        {
            Numero = numero;
        }
        internal string ObterCep()
        {
            return Cep;
        }
        internal void AtribuirCep(string cep)
        {
            Cep = cep;
        }

        #endregion

    }
}
