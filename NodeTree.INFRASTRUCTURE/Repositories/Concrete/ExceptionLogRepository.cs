﻿using Microsoft.EntityFrameworkCore;
using NodeTree.DB;
using NodeTree.DB.Entities;
using NodeTree.INFRASTRUCTURE.DTOs;
using NodeTree.INFRASTRUCTURE.Repositories.Abstract;
using NodeTree.INFRASTRUCTURE.Requests;

namespace NodeTree.INFRASTRUCTURE.Repositories.Concrete
{
    public class ExceptionLogRepository : Repository<ExceptionLog>, IExceptionLogRepository
    {

        private readonly NodeTreeDbContext _context;
        public ExceptionLogRepository(NodeTreeDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ExceptionLogResult> GetExceptionLogAndCountFromDateToDateAndTakeAmout(string search,
            DateTime? from,
            DateTime? to,
            int skip,
            int take)
        {
            var query = _context.ExceptionsLog
            .Where(el => search == null || el.Type.ToLower() == search)
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