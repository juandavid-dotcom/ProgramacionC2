using Microsoft.EntityFrameworkCore;

namespace HomeWork2.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Entity.Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=registrodeencomiendas;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entity.Person>()
                .HasKey(p => p.ids);

            modelBuilder.Entity<Entity.Person>()
                .Property(p => p.ids)
                .ValueGeneratedNever();
        }
    }
}
