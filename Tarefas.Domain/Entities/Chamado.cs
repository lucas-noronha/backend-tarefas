using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Tarefas.Domain.Enums;

namespace Tarefas.Domain.Entities
{
    internal class Chamado
    {
        public Chamado(string titulo, string descricao, DateTime dataPrevista, ETipoChamado tipoChamado, Usuario criador, Cliente cliente)
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;

            Titulo = titulo;
            Descricao = descricao;
            DataPrevista = dataPrevista;
            TipoChamado = tipoChamado;

            CriadorId = criador.BuscarId();
            Criador = criador;
            ClienteId = cliente.BuscarId();
            Cliente = cliente;

            TempoGasto = new List<TempoGasto>();
            Historico = new List<HistoricoChamado>();
        }

        protected Guid Id { get; set; }

        protected string Titulo { get; set; }

        protected string Descricao { get; set; }

        protected DateTime DataPrevista { get; set; }

        protected DateTime DataCriacao { get; set; }

        protected ETipoChamado TipoChamado { get; set; }

        protected Guid CriadorId { get; set; }
        protected Usuario Criador { get; set; }

        protected Guid ResponsavelId { get; set; }
        protected Usuario Responsavel { get; set; }

        protected Guid ClienteId { get; set; }
        protected Cliente Cliente { get; set; }

        protected virtual ICollection<TempoGasto> TempoGasto { get; set; }
        protected virtual ICollection<HistoricoChamado> Historico { get; set; }

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
            ResponsavelId = responsavel.BuscarId();
            Responsavel = responsavel;
        }

        internal Cliente ObterCliente()
        {
            return Cliente;
        }
        internal void AtribuirCliente(Cliente cliente)
        {
            ClienteId = cliente.BuscarId();
            Cliente = cliente;
        }
        #endregion

    }
}
