using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarefas.Domain.Entities
{
    public class HistoricoChamado
    {
        public HistoricoChamado()
        {

        }
        public HistoricoChamado(string anotacao, DateTime dataOcorrencia, Usuario usuario)
        {
            Id = Guid.NewGuid();

            Anotacao = anotacao;
            DataOcorrencia = dataOcorrencia;

            UsuarioId = usuario.ObterId();
            Usuario = usuario;
        }
        public Guid Id { get; set; }

        public string Anotacao { get; set; }

        public Guid UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public DateTime DataOcorrencia { get; set; }

        public Guid ChamadoId { get; set; }
        public Chamado Chamado { get; set; }


    }
}
