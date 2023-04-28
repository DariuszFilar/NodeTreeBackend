using Microsoft.EntityFrameworkCore;
using NodeTree.DB.Entities;

namespace NodeTree.DB
{
    public class NodeTreeSeeder
    {
        private readonly NodeTreeDbContext _context;
        public NodeTreeSeeder(NodeTreeDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Database.CanConnect())
            {
                var pendingMigrations = _context.Database.GetPendingMigrations();
                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    _context.Database.Migrate();
                }

                if (!_context.Nodes.Any())
                {
                    Node masterNode = new()
                    {                        
                        Name = "ExampleNode",
                        TreeName = "ExampleTree"                        
                    };

                    _context.Nodes.Add(masterNode);
                    _context.SaveChanges();
                }
            }
        }
    }
}
