using NodeTree.DB.Entities;

namespace NodeTree.INFRASTRUCTURE.Responses
{
    public class GetSingleExceptionLogResponse
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public Dictionary<string, string> Data { get; set; }
        public DateTime CreatedAt { get; set; }
        public GetSingleExceptionLogResponse(ExceptionLog exceptionLog)
        {
            Type = exceptionLog.Type;
            Id = exceptionLog.Id;
            Data = new Dictionary<string, string>
            {
                { "text", exceptionLog.StackTrace }
            };
            CreatedAt = exceptionLog.CreatedAt;
        }
    }
}

