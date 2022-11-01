using Tarefas.Domain.Entities;

namespace Tarefas.Domain.Dtos
{
    public class HistoricoChamadoDto
    {
        public HistoricoChamadoDto()
        {}
        internal HistoricoChamadoDto(HistoricoChamado historico)
        {
            Id = historico.Id;
            Anotacao = historico.Anotacao;
            DataOcorrencia = historico.DataOcorrencia;

            UsuarioId = historico.UsuarioId;
            Usuario = new UsuarioDto(historico.Usuario);
            ChamadoId = historico.ChamadoId;
            Chamado = new ChamadoDto(historico.Chamado);
        }

        public Guid Id { get; set; }

        public string Anotacao { get; set; }

        public Guid UsuarioId { get; set; }

        public UsuarioDto Usuario { get; set; }

        public DateTime DataOcorrencia { get; set; }

        public Guid ChamadoId { get; set; }
        public ChamadoDto Chamado { get; set; }

        internal HistoricoChamado CriarOuAlterarEntidade(HistoricoChamado? historico = null)
        {
            var referencia = historico;
            if (referencia == null)
            {
                referencia = new HistoricoChamado();
                referencia.Id = Guid.NewGuid();
                referencia.DataOcorrencia = DateTime.Now;
            }

            referencia.Anotacao = Anotacao;
            referencia.UsuarioId = UsuarioId;
            referencia.ChamadoId = ChamadoId;
            
            return referencia;
        }
    }
}