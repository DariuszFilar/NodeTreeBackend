using Microsoft.AspNetCore.Mvc;
using Moq;
using NodeTree.API.Controllers;
using NodeTree.API.Handlers;
using NodeTree.DB.Entities;
using NodeTree.INFRASTRUCTURE.Requests;
using NodeTree.INFRASTRUCTURE.Responses;

namespace NodeTree.TESTS
{
    [TestFixture]
    public class JournalControllerTests
    {
        private Mock<IRequestHandler<GetSingleExceptionLogRequest, GetSingleExceptionLogResponse>> _mockGetSingleExceptionLogHandler;
        private Mock<IRequestWithSkipAndTakeHandler<GetRangeExceptionLogRequest, GetRangeExceptionLogResponse>> _mockGetRangeExceptionLogHandler;
        private JournalController _journalController;

        [SetUp]
        public void Setup()
        {
            _mockGetSingleExceptionLogHandler = new Mock<IRequestHandler<GetSingleExceptionLogRequest, GetSingleExceptionLogResponse>>();
            _mockGetRangeExceptionLogHandler = new Mock<IRequestWithSkipAndTakeHandler<GetRangeExceptionLogRequest, GetRangeExceptionLogResponse>>();
            _journalController = new JournalController(_mockGetSingleExceptionLogHandler.Object, _mockGetRangeExceptionLogHandler.Object);
        }


        [Test]
        public async Task GetSingleEventAsync_WithValidEventId_ReturnsOk()
        {
            // Arrange
            GetSingleExceptionLogRequest request = new() { EventId = 1 };
            GetSingleExceptionLogResponse response = new(new ExceptionLog());
            _ = _mockGetSingleExceptionLogHandler.Setup(x => x.Handle(request)).ReturnsAsync(response);

            // Act
            IActionResult result = await _journalController.GetSingleEventAsync(request);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }
    }
}
