using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Domain.Enums;

namespace Tarefas.Domain.Entities
{
    public class Usuario : Pessoa
    {
        public Usuario()
        {

        }
        public Usuario(string nome, string login, string senhaCriptograda, ETipoUsuario tipoUsuario)
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;

            Nome = nome;
            Login = login;
            Senha = senhaCriptograda;
            TipoUsuario = tipoUsuario;
        }

        public string Login { get; set; }
        public string Senha { get; set; }
        public ETipoUsuario TipoUsuario { get; set; }
        public List<Chamado> Tarefas { get; set; }

        #region Acessadores
        internal string ObterLogin()
        {
            return Login;
        }

        internal void AtribuirLogin(string login)
        {
            Login = login;
        }

        internal string ObterSenha()
        {
            return Senha;
        }

        internal void AtribuirSenha(string senha)
        {
            Senha = senha;
        }

        internal ETipoUsuario ObterTipoUsuario()
        {
            return TipoUsuario;
        }
        #endregion

    }
}
