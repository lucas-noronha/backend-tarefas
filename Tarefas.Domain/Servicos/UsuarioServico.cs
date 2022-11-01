using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Domain.Dtos;
using Tarefas.Domain.Interfaces.Repositorios;

namespace Tarefas.Domain.Servicos
{
    public class UsuarioServico
    {
        private readonly IUsuarioRepositorio repositorio;
        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio)
        {
            repositorio = usuarioRepositorio;
        }

        public UsuarioDto ObterUsuario(Guid id)
        {
            var entidade = repositorio.ObterPorId(id);
            var dto = new UsuarioDto(entidade);

            return dto;            
        }

        public List<UsuarioDto> ObterUsuarios()
        {
            var entidades = repositorio.ObterLista().Where(x => !x.Inativo).ToList();
            var dtos = entidades.Select(x => new UsuarioDto(x)).ToList();

            return dtos;
        }

        public void Cadastrar(UsuarioDto dto)
        {
            var entidade = dto.CriarOuAlterarEntidade();
            repositorio.Adicionar(entidade);
        }

        public void CadastrarLista(ICollection<UsuarioDto> dtos)
        {
            var entidades = dtos.ToList().Select(x => x.CriarOuAlterarEntidade()).ToList();
            repositorio.AdicionarLista(entidades);
        }

        public void Alterar(UsuarioDto dto)
        {
            var entidade = repositorio.ObterPorId(dto.Id);
            dto.CriarOuAlterarEntidade(entidade);
            repositorio.Alterar(entidade);
        }

        public void Inativar(UsuarioDto dto)
        {
            var entidade = repositorio.ObterPorId(dto.Id);
            entidade.Inativo = true;

            repositorio.Alterar(entidade);
        }
    }
}
