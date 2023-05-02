using Microsoft.EntityFrameworkCore;
using NodeTree.DB;
using NodeTree.DB.Entities;
using NodeTree.INFRASTRUCTURE.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeTree.TESTS
{
    [TestFixture]
    internal class TreeRepositoryTests
    {
        private NodeTreeDbContext _context;
        private TreeRepository _repository;

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
                    TreeName = "Tree Name 3",
                    ParentId = null,
                }
            );

            _context.SaveChangesAsync().GetAwaiter().GetResult();

            _repository = new TreeRepository(_context);
        }

        [Test]
        public async Task GetTreeByTreeNameAsync_ReturnTree()
        {
            // Act

            var result = await _repository.GetTreeByTreeNameAsync("Tree Name 1");

            // Assert
            Assert.That(result.TreeName, Is.EqualTo("Tree Name 1"));
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeletedAsync();
        }

    }
}
