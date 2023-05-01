using NodeTree.DB.Entities;
using NodeTree.INFRASTRUCTURE.Requests;
using NodeTree.INFRASTRUCTURE.Responses;
using NodeTree.INFRASTRUCTURE.Services.Abstract;

namespace NodeTree.API.Handlers.Queries
{
    public class GetSingleExceptionLogHandler : IRequestHandler<GetSingleExceptionLogRequest, GetSingleExceptionLogResponse>
    {
        private readonly IExceptionLogService _exceptionLogService;
        public GetSingleExceptionLogHandler(IExceptionLogService exceptionLogService)
        {
            _exceptionLogService = exceptionLogService;
        }
        public async Task<GetSingleExceptionLogResponse> Handle(GetSingleExceptionLogRequest request)
        {
            ExceptionLog exceptionLog = await _exceptionLogService.GetSingleExceptionAsync(request);
            return new GetSingleExceptionLogResponse(exceptionLog);
        }
    }
}
