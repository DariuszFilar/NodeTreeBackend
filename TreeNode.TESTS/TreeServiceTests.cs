using Moq;
using NodeTree.DB.Entities;
using NodeTree.INFRASTRUCTURE.Repositories.Abstract;
using NodeTree.INFRASTRUCTURE.Services.Abstract;
using NodeTree.INFRASTRUCTURE.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeTree.TESTS
{
    [TestFixture]
    public class TreeServiceTests
    {
        private Mock<ITreeRepository> _treeRepositoryMock;
        private TreeService _treeService;

        [SetUp]
        public void Setup()
        {
            _treeRepositoryMock = new Mock<ITreeRepository>();
            _treeService = new TreeService(_treeRepositoryMock.Object);
        }

        [Test]
        public async Task GetTreeAsync_WithExistingTreeName_ReturnsTree()
        {
            // Arrange
            var treeName = "TestTree";
            var tree = new Node { TreeName = treeName };
            _treeRepositoryMock.Setup(x => x.GetTreeByTreeNameAsync(treeName)).ReturnsAsync(tree);

            // Act
            var result = await _treeService.GetTreeAsync(treeName);

            // Assert
            Assert.That(result, Is.EqualTo(tree));
        }

        [Test]
        public async Task GetTreeAsync_WithNonExistingTreeName_AddsAndReturnsTree()
        {
            // Arrange
            var treeName = "TestTree";
            _treeRepositoryMock.Setup(x => x.GetTreeByTreeNameAsync(treeName)).ReturnsAsync((Node)null);

            // Act
            var result = await _treeService.GetTreeAsync(treeName);

            // Assert
            _treeRepositoryMock.Verify(x => x.AddAsync(It.Is<Node>(n => n.TreeName == treeName)), Times.Once);
            Assert.That(treeName, Is.EqualTo(result.TreeName));
        }
    }
}
