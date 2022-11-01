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
        public ClienteServico(IClienteRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }


        public ClienteDto ObterCliente(Guid id)
        {
            var entidade = repositorio.ObterPorId(id);
            var dto = new ClienteDto(entidade);

            return dto;
        }

        public List<ClienteDto> ObterClientes()
        {
            var entidades = repositorio.ObterLista().Where(x => !x.Inativo).ToList();
            var dtos = entidades.Select(x => new ClienteDto(x)).ToList();

            return dtos;
        }

        public void Cadastrar(ClienteDto dto)
        {
            var entidade = dto.CriarOuAlterarEntidade();
            
            repositorio.Adicionar(entidade);
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

        public void Inativar(ClienteDto dto)
        {
            var cliente = repositorio.ObterPorId(dto.Id);
            cliente.Inativo = true;

            repositorio.Alterar(cliente);
        }
    }
}
