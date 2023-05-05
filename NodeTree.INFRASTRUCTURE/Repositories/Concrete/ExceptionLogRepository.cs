using Microsoft.EntityFrameworkCore;
using NodeTree.DB;
using NodeTree.DB.Entities;
using NodeTree.INFRASTRUCTURE.DTOs;
using NodeTree.INFRASTRUCTURE.Repositories.Abstract;

namespace NodeTree.INFRASTRUCTURE.Repositories.Concrete
{
    public class ExceptionLogRepository : Repository<ExceptionLog>, IExceptionLogRepository
    {

        private readonly INodeTreeDbContext _context;
        public ExceptionLogRepository(INodeTreeDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ExceptionLogResult> GetExceptionLogAndCountFromDateToDateAndTakeAmout(string search,
            DateTime? from,
            DateTime? to,
            int skip,
            int take)
        {
            IQueryable<ExceptionLog> query = _context.ExceptionsLog
            .Where(el => search == null || el.Type.ToLower() == search.ToLower())
            .Where(el => !from.HasValue || el.CreatedAt >= from.Value)
            .Where(el => !to.HasValue || el.CreatedAt <= to.Value);

            long count = await query.CountAsync();

            List<ExceptionLog> logs = await query
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            return new ExceptionLogResult { ExceptionLogs = logs, Count = count };
        }
    }
}
