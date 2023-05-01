using NodeTree.DB.Entities;
using NodeTree.INFRASTRUCTURE.DTOs;
using NodeTree.INFRASTRUCTURE.Requests;
using NodeTree.INFRASTRUCTURE.Responses;
using NodeTree.INFRASTRUCTURE.Services.Abstract;

namespace NodeTree.API.Handlers.Commands
{
    public class GetRangeExceptionLogHandler : IRequestWithSkipAndTakeHandler<GetRangeExceptionLogRequest, GetRangeExceptionLogResponse>
    {
        private readonly IExceptionLogService _exceptionLogService;
        public GetRangeExceptionLogHandler(IExceptionLogService exceptionLogService)
        {
            _exceptionLogService = exceptionLogService;
        }
        public async Task<GetRangeExceptionLogResponse> Handle(GetRangeExceptionLogRequest request, int skip, int take)
        {
            ExceptionLogResult exceptionLog = await _exceptionLogService.GetRangeExceptionAsync(request, skip, take);

            return new GetRangeExceptionLogResponse(exceptionLog.ExceptionLogs, skip, exceptionLog.Count);
        }
    }
}
