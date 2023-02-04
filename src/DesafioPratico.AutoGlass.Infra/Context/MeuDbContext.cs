using DesafioPratico.AutoGlass.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioPratico.AutoGlass.Infra.Context
{
    public class MeuDbContext: DbContext
    {
        public MeuDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
