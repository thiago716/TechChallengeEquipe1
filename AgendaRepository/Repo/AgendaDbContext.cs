using Agenda.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Microsoft.Extensions.Configuration;

namespace Agenda.Dados.Repo
{
    public class AgendaDbContext : DbContext
    {
        private readonly string _connection;

        public AgendaDbContext(DbContextOptions<AgendaDbContext> options)
    : base(options)
        {
            // O DbContextOptions já contém a string de conexão.
            _connection = options.FindExtension<SqlServerOptionsExtension>()?.ConnectionString;
        }

        public AgendaDbContext(string connection)
        {
            _connection = connection;
        }

        public DbSet<Contato> Contatos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AgendaDbContext).Assembly);
        }
    }
}
