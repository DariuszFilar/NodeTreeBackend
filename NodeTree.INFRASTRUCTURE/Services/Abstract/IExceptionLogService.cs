using NodeTree.DB.Entities;
using NodeTree.INFRASTRUCTURE.DTOs;
using NodeTree.INFRASTRUCTURE.Requests;

namespace NodeTree.INFRASTRUCTURE.Services.Abstract
{
    public interface IExceptionLogService
    {
        Task<ExceptionLog> GetSingleExceptionAsync(GetSingleExceptionLogRequest request);
        Task<ExceptionLogResult> GetRangeExceptionAsync(GetRangeExceptionLogRequest request, int skip, int take);
        Task<ExceptionLog> CreateExceptionLogAsync<T>(T exception,
            Dictionary<string, string> queryParameters,
            Dictionary<string, string> bodyParameters) where T : Exception;
    }
}
