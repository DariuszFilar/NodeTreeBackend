using NodeTree.DB.Entities;
using NodeTree.INFRASTRUCTURE.DTOs;
using NodeTree.INFRASTRUCTURE.Requests;

namespace NodeTree.INFRASTRUCTURE.Services.Abstract
{
    /// <summary>
    /// Interface for a service that handles exception logs.
    /// </summary>
    public interface IExceptionLogService
    {
        /// <summary>
        /// Retrieves a single exception log by id.
        /// </summary>
        /// <param name="request">Request containing the id of the exception log to retrieve.</param>
        /// <returns>The exception log with the specified id.</returns>
        Task<ExceptionLog> GetSingleExceptionAsync(GetSingleExceptionLogRequest request);

        /// <summary>
        /// Retrieves a range of exception logs with optional filtering and sorting.
        /// </summary>
        /// <param name="request">Request containing filters.</param>
        /// <param name="skip">The number of records to skip before returning records.</param>
        /// <param name="take">The maximum number of records to return.</param>
        /// <returns>A paginated result containing the range of exception logs matching the specified criteria.</returns>
        Task<ExceptionLogResult> GetRangeExceptionAsync(GetRangeExceptionLogRequest request, int skip, int take);

        /// <summary>
        /// Creates an exception log for the specified exception.
        /// </summary>
        /// <typeparam name="T">The type of the exception.</typeparam>
        /// <param name="exception">The exception to log.</param>
        /// <param name="queryParameters">The query parameters of the request that caused the exception.</param>
        /// <param name="bodyParameters">The body parameters of the request that caused the exception.</param>
        /// <returns>The created exception log.</returns>
        Task<ExceptionLog> CreateExceptionLogAsync<T>(T exception,
            Dictionary<string, string> queryParameters,
            Dictionary<string, string> bodyParameters) where T : Exception;
    }
}
