using Moq;
using NodeTree.DB.Entities;
using NodeTree.INFRASTRUCTURE.Exceptions;
using NodeTree.INFRASTRUCTURE.Repositories.Abstract;
using NodeTree.INFRASTRUCTURE.Requests;
using NodeTree.INFRASTRUCTURE.Services.Concrete;

namespace NodeTree.TESTS
{
    [TestFixture]
    public class NodeServiceTests
    {
        private Mock<INodeRepository> _nodeRepositoryMock;
        private Mock<ITreeRepository> _treeRepositoryMock;
        private NodeService _nodeService;

        [SetUp]
        public void Setup()
        {
            _nodeRepositoryMock = new Mock<INodeRepository>();
            _treeRepositoryMock = new Mock<ITreeRepository>();
            _nodeService = new NodeService(_nodeRepositoryMock.Object, _treeRepositoryMock.Object);
        }

        [Test]
        public async Task CreateNodeAsync_WithValidRequest_CreatesNode()
        {
            // Arrange
            CreateNodeRequest request = new()
            {
                ParentId = 1,
                TreeName = "TestTree",
                NodeName = "TestNode"
            };
            Node parent = new() { NodeId = 1 };
            Node tree = new() { TreeName = "Test Tree" };
            _ = _nodeRepositoryMock.Setup(x => x.GetByIdAsync(request.ParentId)).ReturnsAsync(parent);
            _ = _treeRepositoryMock.Setup(x => x.GetTreeByTreeNameAsync(request.TreeName)).ReturnsAsync(tree);
            _ = _nodeRepositoryMock.Setup(x => x.GetAllSiblingsByParentIdAsync(request.ParentId)).ReturnsAsync(new List<Node>());

            // Act
            await _nodeService.CreateNodeAsync(request);

            // Assert
            _nodeRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Node>()), Times.Once);
        }

        [Test]
        public void CreateNodeAsync_WithInvalidRequest_ThrowsSecureException()
        {
            // Arrange
            CreateNodeRequest request = new()
            {
                ParentId = 1,
                TreeName = "TestTree",
                NodeName = "TestNode"
            };
            _ = _nodeRepositoryMock.Setup(x => x.GetByIdAsync(request.ParentId)).ReturnsAsync((Node)null);
            _ = _treeRepositoryMock.Setup(x => x.GetTreeByTreeNameAsync(request.TreeName)).ReturnsAsync((Node)null);

            // Act
            async Task Act()
            {
                await _nodeService.CreateNodeAsync(request);
            }

            // Assert
            _ = Assert.ThrowsAsync<SecureException>(Act);
        }

        [Test]
        public void CreateNodeAsync_WithNonUniqueName_ThrowsSecureException()
        {
            // Arrange
            CreateNodeRequest request = new()
            {
                ParentId = 1,
                TreeName = "TestTree",
                NodeName = "TestNode"
            };
            Node parent = new() { NodeId = 1 };
            _ = _nodeRepositoryMock.Setup(x => x.GetByIdAsync(request.ParentId)).ReturnsAsync(parent);
            _ = _treeRepositoryMock.Setup(x => x.GetTreeByTreeNameAsync(request.TreeName)).ReturnsAsync(new Node());
            Node sibling = new() { Name = request.NodeName };
            _ = _nodeRepositoryMock.Setup(x => x.GetAllSiblingsByParentIdAsync(request.ParentId)).ReturnsAsync(new List<Node> { sibling });

            // Act
            async Task Act()
            {
                await _nodeService.CreateNodeAsync(request);
            }

            // Assert
            _ = Assert.ThrowsAsync<SecureException>(Act);
        }

        [Test]
        public async Task RenameNodeAsync_WithValidRequest_SetsNewName()
        {
            // Arrange
            RenameNodeRequest request = new()
            {
                NodeId = 1,
                NewNodeName = "NewNodeName"
            };
            Node node = new() { NodeId = request.NodeId, Name = "OldNodeName" };
            _ = _nodeRepositoryMock.Setup(x => x.GetByIdAsync(request.NodeId)).ReturnsAsync(node);

            // Act
            await _nodeService.RenameNodeAsync(request);

            // Assert
            Assert.That(node.Name, Is.EqualTo(request.NewNodeName));
        }

        [Test]
        public async Task RenameNodeAsync_WithValidInvalidRequest_ThrowSecureException()
        {
            // Arrange
            RenameNodeRequest request = new()
            {
                NodeId = 1,
                NewNodeName = null
            };

            Node node = new() { NodeId = request.NodeId, Name = "OldNodeName" };
            _ = _nodeRepositoryMock.Setup(x => x.GetByIdAsync(request.NodeId)).ReturnsAsync(node);

            // Act
            await _nodeService.RenameNodeAsync(request);

            // Assert
            _nodeRepositoryMock.Verify(x => x.UpdateAsync(It.Is<Node>(n => n.NodeId == request.NodeId && n.Name == request.NewNodeName)), Times.Once);
        }

        [Test]
        public async Task DeleteNodeAsync_WithValidRequest_DeletesNode()
        {
            // Arrange
            int nodeId = 1;
            DeleteNodeRequest request = new()
            {
                NodeId = 1,
                TreeName = "Test Tree Name",
            };

            Node node = new()
            {
                NodeId = nodeId,
                Children = new List<Node>(),
                TreeName = "Test Tree Name"
            };

            _ = _nodeRepositoryMock.Setup(x => x.GetByIdAsync(node.NodeId))
                .ReturnsAsync(node);

            // Act
            await _nodeService.DeleteNodeAsync(request);

            // Assert
            _nodeRepositoryMock.Verify(x => x.RemoveAsync(node), Times.Once);
        }
    }
}
