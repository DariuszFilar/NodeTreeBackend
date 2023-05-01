using Microsoft.AspNetCore.Mvc;
using NodeTree.API.Handlers;
using NodeTree.INFRASTRUCTURE.Requests;
using NodeTree.INFRASTRUCTURE.Responses;
using System.ComponentModel.DataAnnotations;

namespace NodeTree.API.Controllers
{
    [ApiController]
    [Route("api.user.journal")]
    public class JournalController : Controller
    {
        private readonly IRequestHandler<GetSingleExceptionLogRequest, GetSingleExceptionLogResponse> _getSingleExceptionLogHandler;
        private readonly IRequestWithSkipAndTakeHandler<GetRangeExceptionLogRequest, GetRangeExceptionLogResponse> _getRangeExceptionLogHandler;
        public JournalController(IRequestHandler<GetSingleExceptionLogRequest, GetSingleExceptionLogResponse> getSingleExceptionLogHandler,
            IRequestWithSkipAndTakeHandler<GetRangeExceptionLogRequest, GetRangeExceptionLogResponse> getRangeExceptionLogHandler)
        {
            _getSingleExceptionLogHandler = getSingleExceptionLogHandler;
            _getRangeExceptionLogHandler = getRangeExceptionLogHandler;
        }

        [HttpPost("getSingle")]
        public async Task<IActionResult> GetSingleEvent(GetSingleExceptionLogRequest request)
        {
            var response = await _getSingleExceptionLogHandler.Handle(request);
            return Ok(response);
        }

        [HttpPost("getRange")]
        public async Task<IActionResult> GetRangeEvent([FromBody]GetRangeExceptionLogRequest request, [Required][FromQuery]int skip, [Required][FromQuery]int take)
        {
            var response = await _getRangeExceptionLogHandler.Handle(request, skip, take);
            return Ok(response);
        }
    }
}
