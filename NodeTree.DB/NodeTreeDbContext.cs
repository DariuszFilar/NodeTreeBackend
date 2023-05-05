using Microsoft.EntityFrameworkCore;
using NodeTree.DB.Entities;

namespace NodeTree.DB
{
    public class NodeTreeDbContext : DbContext, INodeTreeDbContext
    {
        private readonly DbContextOptions<NodeTreeDbContext> _options;
        public NodeTreeDbContext(DbContextOptions<NodeTreeDbContext> options)
            : base(options)
        {
            _options = options;
        }

        private readonly string _connectionString =
           "Server=localhost;Port=5432;Database=NodeTreeDb;User Id=postgres;Password=Postgress;";

        public DbSet<Node> Nodes { get; set; }
        public DbSet<ExceptionLog> ExceptionsLog { get; set; }
        public DbSet<BodyParameter> BodyParameters { get; set; }
        public DbSet<QueryParameter> QueryParameters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<Node>()
                .Property(n => n.Name)
                .IsRequired();

            _ = modelBuilder.Entity<Node>()
                .Property(n => n.TreeName)
                .IsRequired();

            _ = modelBuilder.Entity<ExceptionLog>()
                .HasMany(e => e.BodyParameters)
                .WithOne(p => p.ExceptionLog)
                .HasForeignKey(p => p.ExceptionLogId);

            _ = modelBuilder.Entity<ExceptionLog>()
                .HasMany(e => e.QueryParameters)
                .WithOne(p => p.ExceptionLog)
                .HasForeignKey(p => p.ExceptionLogId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                _ = optionsBuilder.UseNpgsql(_connectionString);
            }
        }
    }
}
