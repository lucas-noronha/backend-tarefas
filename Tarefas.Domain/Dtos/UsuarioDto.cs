using Tarefas.Domain.Entities;
using Tarefas.Domain.Enums;

namespace Tarefas.Domain.Dtos
{
    public class UsuarioDto
    {
        public UsuarioDto()
        { }
        internal UsuarioDto(Usuario usuario)
        {
            Id = usuario.Id;
            Nome = usuario.Nome;
            DataCriacao = usuario.DataCriacao;
            Login = usuario.Login;
            Senha = usuario.Senha;
            TipoUsuario = usuario.TipoUsuario;

            Tarefas = usuario.Tarefas.Select(x => new ChamadoDto(x)).ToList();
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public ETipoUsuario TipoUsuario { get; set; }
        public virtual List<ChamadoDto> Tarefas { get; set; }

        internal Usuario CriarEntidade()
        {
            return new Usuario(this);
        }
    }
}