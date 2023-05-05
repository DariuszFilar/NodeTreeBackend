using NodeTree.DB.Entities;
using NodeTree.INFRASTRUCTURE.DTOs;
using NodeTree.INFRASTRUCTURE.Exceptions;
using NodeTree.INFRASTRUCTURE.Repositories.Abstract;
using NodeTree.INFRASTRUCTURE.Requests;
using NodeTree.INFRASTRUCTURE.Services.Abstract;

namespace NodeTree.INFRASTRUCTURE.Services.Concrete
{
    public class ExceptionLogService : IExceptionLogService
    {
        private readonly IExceptionLogRepository _exceptionLogRepository;
        public ExceptionLogService(IExceptionLogRepository exceptionLogRepository)
        {
            _exceptionLogRepository = exceptionLogRepository;
        }
        public async Task<ExceptionLog> GetSingleExceptionAsync(GetSingleExceptionLogRequest request)
        {
            ExceptionLog exceptionLog = await _exceptionLogRepository.GetByIdAsync(request.EventId);
            return exceptionLog ?? throw new SecureException("ExceptionLog not found");
        }

        public async Task<ExceptionLogResult> GetRangeExceptionAsync(GetRangeExceptionLogRequest request, int skip, int take)
        {
            ExceptionLogResult result = await _exceptionLogRepository
                .GetExceptionLogAndCountFromDateToDateAndTakeAmout(request.Search, request.From, request.To, skip, take);

            return result;
        }

        public async Task<ExceptionLog> CreateExceptionLogAsync<T>(T exception,
            List<QueryParameter> queryParameters,
            List<BodyParameter> bodyParameters) where T : Exception
        {
            ExceptionLog exceptionLog = new()
            {
                Type = exception.GetType().Name,
                CreatedAt = DateTime.UtcNow,
                QueryParameters = queryParameters,
                BodyParameters = bodyParameters,
                StackTrace = exception.StackTrace,
                Message = exception.Message
            };

            await _exceptionLogRepository.AddAsync(exceptionLog);
            return exceptionLog;
        }
    }
}
