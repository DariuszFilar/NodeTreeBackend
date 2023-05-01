using NodeTree.DB.Entities;
using NodeTree.INFRASTRUCTURE.DTOs;

namespace NodeTree.INFRASTRUCTURE.Responses
{
    public class GetRangeExceptionLogResponse
    {
        public long Skip { get; set; }
        public long Count { get; set; }
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

