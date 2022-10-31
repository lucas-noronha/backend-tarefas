using Tarefas.Domain.Entities;

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
        public ChamadoDto Chamado { get; set; }

        internal TempoGasto CriarEntidade()
        {
            return new TempoGasto(this);
        }

    }
}