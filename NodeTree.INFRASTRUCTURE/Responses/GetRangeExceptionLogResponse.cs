using NodeTree.DB.Entities;
using NodeTree.INFRASTRUCTURE.DTOs;

namespace NodeTree.INFRASTRUCTURE.Responses
{
    /// <summary>
    /// Represents the response for getting a range of exception logs.
    /// </summary>
    public class GetRangeExceptionLogResponse
    {
        /// <summary>
        /// Gets or sets the number of logs to skip from the beginning of the result set.
        /// </summary>
        public long Skip { get; set; }

        /// <summary>
        /// Gets or sets the total number of logs in the result set.
        /// </summary>
        public long Count { get; set; }

        /// <summary>
        /// Gets or sets the list of exception log items.
        /// </summary>
        public List<ExcetpionLogResponseDto> Items { get; set; }

        public GetRangeExceptionLogResponse(List<ExceptionLog> exceptionLogs, long skip, long count)
        {
            Skip = skip;
            Count = count;
            Items = exceptionLogs.Select(el => new ExcetpionLogResponseDto()
            {
                CreatedAt = el.CreatedAt,
                Id = el.Id
            }).ToList();
        }
    }    
}

