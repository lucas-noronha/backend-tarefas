using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Domain.Dtos;
using Tarefas.Domain.Enums;
using Tarefas.Domain.Interfaces.Repositorios;

namespace Tarefas.Domain.Servicos
{
    public class ChamadoServico
    {
        private readonly IChamadoRepositorio repositorio;
        private readonly IMapper mapper;

        public ChamadoServico(IChamadoRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }


        public ChamadoDto ObterChamado(Guid id)
        {
            var entidade = repositorio.ObterPorId(id);
            var dto = mapper.Map<ChamadoDto>(entidade);

            return dto;
        }

        public List<ChamadoDto> ObterChamadosEmAndamento()
        {
            
            var entidades = repositorio.ListaComVinculos().Where(x => x.Status != EStatusChamado.Finalizado && x.Status != EStatusChamado.Cancelado).ToList();
            var dtos = entidades.Select(x => mapper.Map<ChamadoDto>(x)).ToList();

            return dtos;
        }
        public List<ChamadoDto> ObterChamadosFinalizados()
        {
            var entidades = repositorio.ListaComVinculos().Where(x => x.Status == EStatusChamado.Finalizado || x.Status == EStatusChamado.Cancelado).ToList();
            var dtos = entidades.Select(x => mapper.Map<ChamadoDto>(x)).ToList();

            return dtos;
        }

        public Guid Cadastrar(ChamadoDto dto)
        {
            var entidade = dto.CriarOuAlterarEntidade();
            repositorio.Adicionar(entidade);

            return entidade.Id;
        }

        public void CadastrarLista(ICollection<ChamadoDto> dtos)
        {
            var entidades = dtos.ToList().Select(x => x.CriarOuAlterarEntidade()).ToList();

            repositorio.AdicionarLista(entidades);
        }

        public void Alterar(ChamadoDto dto)
        {
            var entidade = repositorio.ObterPorId(dto.Id);
            dto.CriarOuAlterarEntidade(entidade);
            repositorio.Alterar(entidade);
        }

        public void Cancelar(Guid id)
        {
            var entidade = repositorio.ObterPorId(id);
            entidade.Status = EStatusChamado.Cancelado;
            repositorio.Alterar(entidade);
        }

        public void AdicionarTempoAoChamado(TempoGastoDto dto)
        {
            var entidade = dto.CriarOuAlterarEntidade();

            repositorio.AdicionarTempoGasto(entidade);
        }

        public void AdicionarHistorico(HistoricoChamadoDto dto)
        {
            var entidade = dto.CriarOuAlterarEntidade();

            repositorio.AdicionarHistorico(entidade);
        }

        public void RemoverTempoGasto(Guid tempoId)
        {
            repositorio.RemoverTempoGasto(tempoId);
        }

        public void RemoverHistoricoDeChamado(Guid historicoId)
        {
            repositorio.RemoverHistorico(historicoId);
        }


    }
}
