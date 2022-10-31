using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Domain.Entities;
using Tarefas.Domain.Enums;
using Tarefas.Domain.Interfaces.Repositorios;

namespace Tarefas.Data.Repositorios
{
    public class UsuarioRepositorio : RepositorioPadrao<Usuario>, IUsuarioRepositorio
    {
        public TarefasDb DataContext { get; }

        public UsuarioRepositorio(TarefasDb dataContext) : base(dataContext)
        {
            DataContext = dataContext;
        }


        public Usuario ObterPorLogin(string login)
        {
            var usuario = DataContext.Usuarios.FirstOrDefault(x => x.Login == login);
            return usuario;
        }

        public IQueryable<Usuario> ObterPorTipo(ETipoUsuario tipo)
        {
            var usuarios = DataContext.Usuarios.Where(x => x.TipoUsuario == tipo);

            return usuarios;
        }

        public override IQueryable<Usuario> ObterPorDataCriacao(DateTime date)
        {
            var usuarios = DataContext.Usuarios.Where(x => x.DataCriacao == date);

            return usuarios;
        }

        public override IQueryable<Usuario> ListaComVinculos()
        {
            var usuarios = DataContext.Usuarios
                .Include(x => x.Tarefas);

            return usuarios;
        }
    }
}
