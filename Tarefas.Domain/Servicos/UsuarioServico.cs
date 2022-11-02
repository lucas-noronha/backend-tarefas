using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Domain.Dtos;
using Tarefas.Domain.Handlers;
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

        public Guid Cadastrar(UsuarioDto dto)
        {
            var entidade = dto.CriarOuAlterarEntidade();
            repositorio.Adicionar(entidade);

            return entidade.Id;
        }

        public void CadastrarLista(ICollection<UsuarioDto> dtos)
        {
            var entidades = dtos.ToList().Select(x => x.CriarOuAlterarEntidade()).ToList();
            repositorio.AdicionarLista(entidades);
        }

        public void Alterar(UsuarioDto dto)
        {
            var entidade = repositorio.ObterPorId(dto.Id.GetValueOrDefault());
            dto.CriarOuAlterarEntidade(entidade);
            repositorio.Alterar(entidade);
        }

        public void Inativar(Guid id)
        {
            var entidade = repositorio.ObterPorId(id);
            entidade.Inativo = true;

            repositorio.Alterar(entidade);
        }

        public UsuarioDto Login(string login, string senha)
        {
            var hash = new HashHandler();

            var entidade = repositorio.ObterPorLogin(login);
            if (entidade != null)
            {
                var sucessoLogin = hash.VerificarSenha(senha, entidade.Senha);
                if (sucessoLogin)
                {
                    return new UsuarioDto(entidade);
                }
            }

            return null;
        }

        public bool AlterarSenha(string login, string senhaAtual, string novaSenha)
        {
            var hash = new HashHandler();
            var entidade = repositorio.ObterPorLogin(login);

            var senhaAtualCorreta = hash.VerificarSenha(senhaAtual, entidade.Senha);

            if (senhaAtualCorreta)
            {
                entidade.Senha = hash.CriptografarSenha(novaSenha);
                repositorio.Alterar(entidade);

                return true;
            }

            return false;            
        }

    }
}
