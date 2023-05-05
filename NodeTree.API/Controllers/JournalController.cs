using Microsoft.AspNetCore.Mvc;
using NodeTree.API.Handlers;
using NodeTree.INFRASTRUCTURE.Requests;
using NodeTree.INFRASTRUCTURE.Responses;
using Swashbuckle.AspNetCore.Annotations;
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
        [SwaggerOperation(
            Summary = "Returns the information about a single exception log by ID.",
            Description = "Returns single exception log specified by the ID provided in the request object."
            )]
        public async Task<IActionResult> GetSingleEventAsync(GetSingleExceptionLogRequest request)
        {
            GetSingleExceptionLogResponse response = await _getSingleExceptionLogHandler.Handle(request);
            return Ok(response);
        }

        [SwaggerOperation(
           Summary = "Returns a range of exceptions logs.",
           Description = "Returns a range of exception logs with the specified parameters."
           )]
        [HttpPost("getRange")]
        public async Task<IActionResult> GetRangeEventAsync([FromBody] GetRangeExceptionLogRequest request, [Required][FromQuery] int skip, [Required][FromQuery] int take)
        {
            GetRangeExceptionLogResponse response = await _getRangeExceptionLogHandler.Handle(request, skip, take);
            return Ok(response);
        }
    }
}
