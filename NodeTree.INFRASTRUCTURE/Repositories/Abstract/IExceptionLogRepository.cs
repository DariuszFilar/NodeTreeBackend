using NodeTree.DB.Entities;
using NodeTree.INFRASTRUCTURE.DTOs;
using NodeTree.INFRASTRUCTURE.Requests;

namespace NodeTree.INFRASTRUCTURE.Repositories.Abstract
{
    public interface IExceptionLogRepository : IRepository<ExceptionLog>
    {
        Task<ExceptionLogResult> GetExceptionLogAndCountFromDateToDateAndTakeAmout(string search,
            DateTime? from,
            DateTime? to,
            int skip,
            int take);
    }
}
