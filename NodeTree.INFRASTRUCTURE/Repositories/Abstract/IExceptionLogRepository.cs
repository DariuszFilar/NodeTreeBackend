using NodeTree.DB.Entities;
using NodeTree.INFRASTRUCTURE.DTOs;

namespace NodeTree.INFRASTRUCTURE.Repositories.Abstract
{
    /// <summary>
    /// Interface for exception log repository.
    /// </summary>
    public interface IExceptionLogRepository : IRepository<ExceptionLog>
    {
        /// <summary>
        /// Retrieves exception logs that match the specified search criteria and returns them with their total count.
        /// </summary>
        /// <param name="search">The search query to match.</param>
        /// <param name="from">The minimum date of creation.</param>
        /// <param name="to">The maximum date of creation.</param>
        /// <param name="skip">The number of results to skip.</param>
        /// <param name="take">The number of results to take.</param>
        /// <returns>An <see cref="ExceptionLogResult"/> object containing the matching exception logs and their total count.</returns>
        Task<ExceptionLogResult> GetExceptionLogAndCountFromDateToDateAndTakeAmout(string search,
            DateTime? from,
            DateTime? to,
            int skip,
            int take);
    }
}
