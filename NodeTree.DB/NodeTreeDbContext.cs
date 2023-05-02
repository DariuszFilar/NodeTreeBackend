using Microsoft.EntityFrameworkCore;
using NodeTree.DB.Entities;

namespace NodeTree.DB
{
    public class NodeTreeDbContext : DbContext, INodeTreeDbContext
    {
        private string _connectionString =
           "Server=localhost;Port=5432;Database=NodeTreeDb;User Id=postgres;Password=Postgress;";

        public DbSet<Node> Nodes { get; set; }
        public DbSet<ExceptionLog> ExceptionsLog { get; set; }
        public DbSet<BodyParameter> BodyParameters { get; set; }
        public DbSet<QueryParameter> QueryParameters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Node>()
                .Property(n => n.Name)
                .IsRequired();

            modelBuilder.Entity<Node>()
                .Property(n => n.TreeName)
                .IsRequired();

            modelBuilder.Entity<ExceptionLog>()
                .HasMany(e => e.BodyParameters)
                .WithOne(p => p.ExceptionLog)
                .HasForeignKey(p => p.ExceptionLogId);

            modelBuilder.Entity<ExceptionLog>()
                .HasMany(e => e.QueryParameters)
                .WithOne(p => p.ExceptionLog)
                .HasForeignKey(p => p.ExceptionLogId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }
    }
}
