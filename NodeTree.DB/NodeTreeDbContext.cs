using Microsoft.EntityFrameworkCore;

namespace NodeTree.DB
{
    public class NodeTreeDbContext : DbContext
    {
        private string _connectionString =
           "Server=localhost;Port=5432;Database=NodeTreeDb;User Id=postgres;Password=Postgress;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }
    }
}
