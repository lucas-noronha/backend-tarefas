
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarefas.Domain.Entities
{
    internal class Pessoa
    {
        protected Guid Id { get; set; }
        protected string Nome { get; set; }
        protected DateTime DataCriacao { get; set; }

        #region Acessadores
        internal Guid ObterId()
        {
            return Id;
        }
        internal string BuscarNome()
        {
            return Nome;
        }

        internal void AtribuirNome(string nome)
        {
            Nome = nome;
        }
        internal DateTime BuscarDataCriacao()
        {
            return DataCriacao;
        }
        #endregion
    }
}
