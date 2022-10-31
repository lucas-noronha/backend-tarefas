using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Domain.Entities;
using Tarefas.Domain.Enums;

namespace Tarefas.Domain.Interfaces.Repositorios
{
    public interface IUsuarioRepositorio : IRepositorioPadrao<Usuario>
    {
        Usuario ObterPorLogin(string login);
        IQueryable<Usuario> ObterPorTipo(ETipoUsuario tipo);

    }
}
