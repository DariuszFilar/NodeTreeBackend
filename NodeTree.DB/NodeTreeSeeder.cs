﻿using Microsoft.EntityFrameworkCore;
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
                IEnumerable<string> pendingMigrations = _context.Database.GetPendingMigrations();
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

                    _ = _context.Nodes.Add(masterNode);
                    _ = _context.SaveChanges();
                }

                if (!_context.ExceptionsLog.Any())
                {
                    ExceptionLog exceptionLog = new()
                    {
                        CreatedAt = DateTime.UtcNow,
                        BodyParameters = new List<BodyParameter>()
                        {
                            new BodyParameter
                            {
                                Key = "test",
                                Value = "test"
                            }
                        },
                        Message = "test",
                        Type = "SecureException",
                        QueryParameters = new List<QueryParameter>()
                        {
                            new QueryParameter
                            {
                                Key = "test",
                                Value = "test"
                            }
                        },
                        StackTrace = "test"
                    };

                    _ = _context.ExceptionsLog.Add(exceptionLog);
                    _ = _context.SaveChanges();
                }
            }
        }
    }
}
