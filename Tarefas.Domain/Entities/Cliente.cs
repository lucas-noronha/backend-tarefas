using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Domain.Dtos;
using Tarefas.Domain.Interfaces;

namespace Tarefas.Domain.Entities
{
    public class Cliente : Pessoa, IEndereco
    {
        public Cliente()
        { }

        public Cliente(string nome, string bairro, string cidade, string uf, string logradouro, string numero, string cep)
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;

            Nome = nome;
            Bairro = bairro;
            Cidade = cidade;
            UF = uf;
            Logradouro = logradouro;
            Numero = numero;
            Cep = cep;
        }

        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }

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
            if (uf.Length != 2)
            {
                throw new Exception("UF precisa conter 2 caracteres!");
            }
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
