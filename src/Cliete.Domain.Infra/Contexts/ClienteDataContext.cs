using Microsoft.EntityFrameworkCore;

namespace Cliente.Domain.Infra.Contexts
{
    public class ClienteDataContext : DbContext
    {
        public ClienteDataContext(DbContextOptions<ClienteDataContext> options) : base(options)
        {
        }

        public DbSet<Entities.Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Cliente>(entity =>
            {
                entity.ToTable("cliente");
                entity.HasKey(e => e.Id).HasName("PK_clienteId");
                entity.Property(e => e.Nome).IsRequired().HasColumnType("varchar(100)");
                entity.Property(e => e.Idade).IsRequired().HasColumnType("tinyint");
            });
        }
    }
}
