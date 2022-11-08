using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Domain.Entidades;
using Tarefas.Domain.Enums;

namespace Tarefas.Domain.Dtos
{
    public class ChamadoDto
    {
        public ChamadoDto()
        {}

        internal ChamadoDto(Chamado chamado)
        {
            Id = chamado.Id;
            Titulo = chamado.Titulo;
            Descricao = chamado.Descricao;
            DataPrevista = chamado.DataPrevista;
            DataCriacao = chamado.DataCriacao;
            TipoChamado = chamado.TipoChamado;
            CriadorId = chamado.CriadorId;
            ResponsavelId = chamado.ResponsavelId;
            ClienteId = chamado.ClienteId;
            Status = chamado.Status;

            if (chamado.TempoGasto.Any())
            {
                TempoGasto = chamado.TempoGasto.ToList().Select(x => new TempoGastoDto(x)).ToList();
            }
            if (chamado.Historico.Any())
            {
                Historico = chamado.Historico.ToList().Select(x => new HistoricoChamadoDto(x)).ToList();
            }

            Criador = new UsuarioDto(chamado.Criador);
            Responsavel = new UsuarioDto(chamado.Responsavel);
            Cliente = new ClienteDto(chamado.Cliente);
        }

        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPrevista { get; set; }
        public DateTime DataCriacao { get; set; }
        public ETipoChamado TipoChamado { get; set; }
        public Guid CriadorId { get; set; }
        public UsuarioDto? Criador { get; set; }
        public Guid ResponsavelId { get; set; }
        public UsuarioDto? Responsavel { get; set; }
        public Guid ClienteId { get; set; }
        public ClienteDto? Cliente { get; set; }
        public EStatusChamado Status { get; set; }
        public List<TempoGastoDto>? TempoGasto { get; set; }
        public List<HistoricoChamadoDto>? Historico { get; set; }

        internal Chamado CriarOuAlterarEntidade(Chamado? chamado = null)
        {
            var referencia = chamado;
            if (referencia == null)
            {
                referencia = new Chamado();
                referencia.Id = Guid.NewGuid();
                referencia.DataCriacao = DateTime.Now;
            }
            

            referencia.Titulo = Titulo;
            referencia.Descricao = Descricao;
            referencia.DataPrevista = DataPrevista;
            referencia.TipoChamado = TipoChamado;


            referencia.CriadorId = CriadorId;
            referencia.ResponsavelId = ResponsavelId;
            referencia.ClienteId = ClienteId;
            
            return referencia;
        }
    }
}
