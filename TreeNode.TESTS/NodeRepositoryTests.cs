using Microsoft.EntityFrameworkCore;
using NodeTree.DB.Entities;
using NodeTree.DB;
using NodeTree.INFRASTRUCTURE.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeTree.TESTS
{
    public class NodeRepositoryTests
    {
        private NodeTreeDbContext _context;
        private NodeRepository _repository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<NodeTreeDbContext>()
                .UseInMemoryDatabase(databaseName: "NodeTreeTestDb")
                .Options;

            _context = new NodeTreeDbContext(options);

            _context.Nodes.AddRange(
                new Node
                {
                    Name = "Tree1",
                    NodeId = 1,
                    Parent = null,
                    TreeName = "Tree Name 1",
                    ParentId = null,
                },
                new Node
                {
                    Name = "Tree2",
                    NodeId = 2,
                    Parent = null,
                    TreeName = "Tree Name 2",
                    ParentId = null,
                },
                new Node
                {
                    Name = "Tree3",
                    NodeId = 3,
                    Parent = null,
                    TreeName = "Tree Name 2",
                    ParentId = 2,
                },
                new Node
                {
                    Name = "Tree3",
                    NodeId = 4,
                    Parent = null,
                    TreeName = "Tree Name 3",
                    ParentId = null,
                }
            );

            _context.SaveChangesAsync().GetAwaiter().GetResult();

            _repository = new NodeRepository(_context);
        }

        [Test]
        public async Task GetAllAsync_ReturnsAllNodes()
        {
            // Act

            var result = await _repository.GetAllAsync();

            // Assert
            Assert.That(result.Count, Is.EqualTo(4));
        }

        [Test]
        public async Task GetAllSiblingsByParentIdAsync_ReturnsAllSiblingNodes()
        {
            // Arrange
            Node node = new()
            {
                Name = "To be change",
                TreeName = "Tree 1",
                NodeId = 1
            };

            // Act

            var result = await _repository.GetAllSiblingsByParentIdAsync(2);

            // Assert
            Assert.That(result.Count, Is.EqualTo(1));
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeletedAsync();
        }

    }
}
