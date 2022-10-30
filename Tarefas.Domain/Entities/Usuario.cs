using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Domain.Enums;

namespace Tarefas.Domain.Entities
{
    internal class Usuario : Pessoa
    {
        internal Usuario(string nome, string login, string senhaCriptograda, ETipoUsuario tipoUsuario)
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.Now;

            Nome = nome;
            Login = login;
            Senha = senhaCriptograda;
            TipoUsuario = tipoUsuario;
        }


        

        protected string Login { get; set; }

        protected string Senha { get; set; }

        protected ETipoUsuario TipoUsuario { get; set; }

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
