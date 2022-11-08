using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Domain.Dtos;

namespace Tarefas.Domain.Entidades
{
    public class HistoricoChamado
    {
        public HistoricoChamado()
        {

        }

        public HistoricoChamado(string anotacao, DateTime dataOcorrencia, Usuario usuario, Chamado chamado)
        {
            Id = Guid.NewGuid();

            Anotacao = anotacao;
            DataOcorrencia = dataOcorrencia;

            UsuarioId = usuario.ObterId();
            Usuario = usuario;

            ChamadoId = chamado.Id;
            Chamado = chamado;
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
