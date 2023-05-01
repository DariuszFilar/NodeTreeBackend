using NodeTree.DB.Entities;

namespace NodeTree.INFRASTRUCTURE.Responses
{
    public class ExceptionMiddlewareResponse
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public Dictionary<string, string> Data { get; set; }

        public ExceptionMiddlewareResponse(ExceptionLog exceptionLog)
        {
            Type = exceptionLog.Type;
            Id = exceptionLog.Id.ToString();
            Data = new Dictionary<string, string>
        {
            { "message", exceptionLog.Message }
        };
        }
    }
}
