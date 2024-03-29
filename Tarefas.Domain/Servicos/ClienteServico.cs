﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Domain.Dtos;
using Tarefas.Domain.Interfaces.Repositorios;

namespace Tarefas.Domain.Servicos
{
    public class ClienteServico
    {
        private readonly IClienteRepositorio repositorio;
        private readonly IMapper mapper;

        public ClienteServico(IClienteRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }


        public ClienteDto ObterCliente(Guid id)
        {
            var entidade = repositorio.ObterPorId(id);
            var dto = mapper.Map<ClienteDto>(entidade);

            return dto;
        }

        public List<ClienteDto> ObterClientes()
        {
            var entidades = repositorio.ObterLista().Where(x => !x.Inativo).ToList();
            var dtos = entidades.Select(x => mapper.Map<ClienteDto>(x)).ToList();

            return dtos;
        }

        public Guid Cadastrar(ClienteDto dto)
        {
            var entidade = dto.CriarOuAlterarEntidade();
            
            repositorio.Adicionar(entidade);

            return entidade.Id;
        }

        public void CadastrarLista(ICollection<ClienteDto> dtos)
        {
            var entidades = dtos.ToList().Select(x => x.CriarOuAlterarEntidade()).ToList();

            repositorio.AdicionarLista(entidades);
        }

        public void Alterar(ClienteDto dto)
        {
            var cliente = repositorio.ObterPorId(dto.Id);
            dto.CriarOuAlterarEntidade(cliente);
            repositorio.Alterar(cliente);    
        }

        public void Inativar(Guid id)
        {
            var cliente = repositorio.ObterPorId(id);
            cliente.Inativo = true;

            repositorio.Alterar(cliente);
        }
    }
}
