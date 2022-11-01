using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Domain.Entities;
using Tarefas.Domain.Interfaces.Repositorios;

namespace Tarefas.Data.Repositorios
{
    public class ChamadoRepositorio : IRepositorioPadrao<Chamado>, IChamadoRepositorio
    {
        public TarefasDb DataContext { get; }

        public ChamadoRepositorio(TarefasDb DataContext)
        {
            this.DataContext = DataContext;
        }
        public IQueryable<Chamado> ObterPorResponsavel(Guid responsavelId)
        {
            var chamados = DataContext.Chamados
                .Include(x => x.Criador)
                .Include(x => x.Cliente)
                .Include(x => x.Responsavel)
                .Include(x => x.TempoGasto)
                .Include(x => x.Historico)
                .Where(x => x.ResponsavelId == responsavelId);

            return chamados;
        }

        public IQueryable<Chamado> ObterPorCliente(Guid clienteId)
        {
            var chamados = DataContext.Chamados
                .Include(x => x.Criador)
                .Include(x => x.Cliente)
                .Include(x => x.Responsavel)
                .Include(x => x.TempoGasto)
                .Include(x => x.Historico)
                .Where(x => x.ClienteId == clienteId);

            return chamados;
        }

        public IQueryable<Chamado> ObterPorDataCriacao(DateTime data)
        {
            var chamados = DataContext.Chamados
                .Include(x => x.Criador)
                .Include(x => x.Cliente)
                .Include(x => x.Responsavel)
                .Include(x => x.TempoGasto)
                .Include(x => x.Historico)
                .Where(x => x.DataCriacao == data);

            return chamados;
        }
        public IQueryable<Chamado> ListaComVinculos()
        {
            var chamados = DataContext.Chamados
                .Include(x => x.Criador)
                .Include(x => x.Cliente)
                .Include(x => x.Responsavel)
                .Include(x => x.TempoGasto)
                .Include(x => x.Historico);

            return chamados;
        }

        public Chamado ObterPorId(Guid id)
        {
            var chamado = DataContext.Chamados
                .Include(x => x.Criador)
                .Include(x => x.Cliente)
                .Include(x => x.Responsavel)
                .Include(x => x.TempoGasto)
                .Include(x => x.Historico)
                .FirstOrDefault(x => x.Id == id);

            return chamado;
        }

        public IQueryable<Chamado> ObterLista()
        {
            return DataContext.Chamados;
        }

        public bool Adicionar(Chamado entidade)
        {
            DataContext.Add(entidade);
            DataContext.SaveChanges();

            return true;
        }

        public bool AdicionarLista(ICollection<Chamado> chamados)
        {
            DataContext.AddRange(chamados);
            DataContext.SaveChanges();

            return true;
        }

        public void Alterar(Chamado entidade)
        {
            DataContext.Entry(entidade).State = EntityState.Modified;
            DataContext.SaveChanges();
        }

        public void Deletar(Chamado entidade)
        {
            DataContext.Remove(entidade);
        }

        
        public void AdicionarHistorico(HistoricoChamado historicoChamado)
        {
            DataContext.HistoricosChamados.Add(historicoChamado);
            DataContext.SaveChanges();
        }

        public void AdicionarTempoGasto(TempoGasto tempoGasto)
        {
            DataContext.TemposGastos.Add(tempoGasto);
            DataContext.SaveChanges();
        }

        public void RemoverHistorico(Guid historicoId)
        {
            var entidade = DataContext.HistoricosChamados.First(x => x.Id == historicoId);
            DataContext.HistoricosChamados.Remove(entidade);
            DataContext.SaveChanges();
        }

        public void RemoverTempoGasto(Guid tempoId)
        {
            var entidade = DataContext.TemposGastos.First(x => x.Id == tempoId);
            DataContext.TemposGastos.Remove(entidade);
            DataContext.SaveChanges();
        }
    }
}
