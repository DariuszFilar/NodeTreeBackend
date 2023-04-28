using Microsoft.EntityFrameworkCore;
using NodeTree.DB.Entities;

namespace NodeTree.DB
{
    public class NodeTreeDbContext : DbContext
    {
        private string _connectionString =
           "Server=localhost;Port=5432;Database=NodeTreeDb;User Id=postgres;Password=Postgress;";

        public DbSet<Node> Nodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Node>()
                .Property(n => n.Name)
                .IsRequired();

            modelBuilder.Entity<Node>()
                .Property(n => n.TreeName)
                .IsRequired();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }
    }
}
