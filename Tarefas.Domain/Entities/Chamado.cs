using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Tarefas.Domain.Dtos;
using Tarefas.Domain.Enums;

namespace Tarefas.Domain.Entities
{
    public class Chamado
    {
        public Chamado()
        {

        }

        internal Chamado(ChamadoDto dto)
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;

            Titulo = dto.Titulo;
            Descricao = dto.Descricao;
            DataPrevista = dto.DataPrevista;
            TipoChamado = dto.TipoChamado;

            CriadorId = dto.CriadorId;
            Criador = new Usuario(dto.Criador);
            
            ResponsavelId = dto.ResponsavelId;
            Responsavel = new Usuario(dto.Responsavel);

            ClienteId = dto.ClienteId;
            Cliente = new Cliente(dto.Cliente);
            
            TempoGasto = dto.TempoGasto.Select(x => new TempoGasto(x)).ToList();
            Historico = dto.Historico.Select(x => new HistoricoChamado(x)).ToList();
        }

        public Chamado(string titulo, string descricao, DateTime dataPrevista, ETipoChamado tipoChamado, Usuario criador, Cliente cliente)
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;

            Titulo = titulo;
            Descricao = descricao;
            DataPrevista = dataPrevista;
            TipoChamado = tipoChamado;

            CriadorId = criador.ObterId();
            Criador = criador;
            ResponsavelId = criador.ObterId();
            Responsavel = criador;

            ClienteId = cliente.ObterId();
            Cliente = cliente;

            TempoGasto = new List<TempoGasto>();
            Historico = new List<HistoricoChamado>();
        }

        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPrevista { get; set; }
        public DateTime DataCriacao { get; set; }
        public ETipoChamado TipoChamado { get; set; }
        public Guid CriadorId { get; set; }
        public Usuario Criador { get; set; }
        public Guid ResponsavelId { get; set; }
        public Usuario Responsavel { get; set; }
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public EStatusChamado Status { get; set; }
        public virtual ICollection<TempoGasto> TempoGasto { get; set; }
        public virtual ICollection<HistoricoChamado> Historico { get; set; }

        #region Acessadores

        internal Guid BuscarId()
        {
            return Id;
        }
        internal string ObterTitulo()
        {
            return Titulo;
        }
        internal void AtribuirTitulo(string titulo)
        {
            Titulo = titulo;
        }
        internal string ObterDescricao()
        {
            return Descricao;
        }
        internal void AtribuirDescricao(string descricao)
        {
            Descricao = descricao;
        }
        internal DateTime ObterDataPrevista()
        {
            return DataPrevista;
        }
        internal void AtribuirDataPrevista(DateTime dataPrevista)
        {
            DataPrevista = dataPrevista;
        }
        internal DateTime ObterDataCriacao()
        {
            return DataCriacao;
        }

        internal ETipoChamado ObterTipoChamado()
        {
            return TipoChamado;
        }
        internal void ObterTipoChamado(ETipoChamado tipoChamado)
        {
            TipoChamado = tipoChamado;
        }

        internal Usuario ObterCriadorChamado()
        {
            return Criador;
        }

        internal Usuario ObterResponsavel()
        {
            return Responsavel;
        }
        internal void AtribuirResponsavel(Usuario responsavel)
        {
            ResponsavelId = responsavel.ObterId();
            Responsavel = responsavel;
        }

        internal Cliente ObterCliente()
        {
            return Cliente;
        }
        internal void AtribuirCliente(Cliente cliente)
        {
            ClienteId = cliente.ObterId();
            Cliente = cliente;
        }
        #endregion

    }
}
