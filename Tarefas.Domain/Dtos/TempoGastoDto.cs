using Tarefas.Domain.Entidades;

namespace Tarefas.Domain.Dtos
{
    public class TempoGastoDto
    {
        public TempoGastoDto()
        { }
        internal TempoGastoDto(TempoGasto tempoGasto)
        {
            Id = tempoGasto.Id;
            Tempo = tempoGasto.Tempo;
            Atividade = tempoGasto.Atividade;
            DataAtividade = tempoGasto.DataAtividade;
            ChamadoId = tempoGasto.ChamadoId;
            Chamado = new ChamadoDto(tempoGasto.Chamado);
        }

        public Guid Id { get; set; }
        public TimeSpan Tempo { get; set; }
        public string Atividade { get; set; }
        public DateTime DataAtividade { get; set; }
        public Guid ChamadoId { get; set; }
        public ChamadoDto? Chamado { get; set; }

        internal TempoGasto CriarOuAlterarEntidade(TempoGasto? tempoGasto = null)
        {
            var referencia = tempoGasto;
            if (referencia == null)
            {
                referencia = new TempoGasto();
                referencia.Id = Guid.NewGuid();
            }

            referencia.Tempo = Tempo;
            referencia.Atividade = Atividade;
            referencia.DataAtividade = DataAtividade;
            referencia.ChamadoId = ChamadoId;

            return referencia;
        }

    }
}