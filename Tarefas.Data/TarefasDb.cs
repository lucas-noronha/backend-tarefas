using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Runtime.InteropServices;
using Tarefas.Domain.Entities;

namespace Tarefas.Data
{
    public class TarefasDb : DbContext
    {
        public TarefasDb(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

        public DbSet<Chamado> Chamados { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<HistoricoChamado> HistoricosChamados { get; set; }

        public DbSet<TempoGasto> TemposGastos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}