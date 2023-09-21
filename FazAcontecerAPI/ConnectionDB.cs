using FazAcontecerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FazAcontecerAPI
{
    public class ConnectionDB: DbContext
    {
        public DbSet<Usuario> TbUsuario { get; set; }

        public DbSet<Evento> TbEvento { get; set; }

        public DbSet<Convidado> TbConvidado { get; set; }

        public DbSet<Categoria> TbCategoria { get; set; }

        public DbSet<Aperitivo> TbAperitivo { get; set; }

        public DbSet<Decoracao> TbDecoracao { get; set; }

        public ConnectionDB(DbContextOptions<ConnectionDB> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Tb_Usuario").HasKey(u => u.Id);

            modelBuilder.Entity<Evento>().ToTable("Tb_Evento").HasKey(u => u.Id);

            modelBuilder.Entity<Convidado>().ToTable("Tb_Convidado").HasKey(u => u.Id);

            modelBuilder.Entity<Categoria>().ToTable("Tb_Categoria").HasKey(u => u.Id);

            modelBuilder.Entity<Aperitivo>().ToTable("Tb_Aperitivo").HasKey(u => u.Id);

            modelBuilder.Entity<Decoracao>().ToTable("Tb_Decoracao").HasKey(u => u.Id);
        }

    }
}
