using Microsoft.AspNetCore.Mvc;
using Moq;
using NodeTree.API.Controllers;
using NodeTree.API.Handlers;
using NodeTree.DB.Entities;
using NodeTree.INFRASTRUCTURE.Exceptions;
using NodeTree.INFRASTRUCTURE.Repositories.Abstract;
using NodeTree.INFRASTRUCTURE.Requests;
using NodeTree.INFRASTRUCTURE.Responses;
using NodeTree.INFRASTRUCTURE.Services.Abstract;

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
            var request = new GetSingleExceptionLogRequest { EventId = 1 };
            var response = new GetSingleExceptionLogResponse(new ExceptionLog());
            _mockGetSingleExceptionLogHandler.Setup(x => x.Handle(request)).ReturnsAsync(response);

            // Act
            var result = await _journalController.GetSingleEventAsync(request);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }
    }
}
