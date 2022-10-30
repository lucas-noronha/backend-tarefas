using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarefas.Domain.Entities
{
    internal class HistoricoChamado
    {
        internal HistoricoChamado(string anotacao, DateTime dataAnotacao, Usuario usuario)
        {
            Id = Guid.NewGuid();

            Anotacao = anotacao;
            DataAnotacao = dataAnotacao;

            UsuarioId = usuario.ObterId();
            Usuario = usuario;
        }
        public Guid Id { get; set; }

        public string Anotacao { get; set; }

        public Guid UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public DateTime DataAnotacao { get; set; }
    }
}
