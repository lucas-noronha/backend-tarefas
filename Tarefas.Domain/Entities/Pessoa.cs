
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarefas.Domain.Entities
{
    public abstract class Pessoa
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Inativo { get; set; } = false;

        #region Acessadores
        internal Guid ObterId()
        {
            return Id;
        }
        internal string ObterNome()
        {
            return Nome;
        }

        internal void AtribuirNome(string nome)
        {
            Nome = nome;
        }
        internal DateTime ObterDataCriacao()
        {
            return DataCriacao;
        }
        #endregion
    }
}
