using NodeTree.DB.Entities;

namespace NodeTree.INFRASTRUCTURE.Responses
{
    /// <summary>
    /// Represents the response sent by the exception middleware in case of an unhandled exception.
    /// </summary>
    public class ExceptionMiddlewareResponse
    {
        /// <summary>
        /// The type of the exception.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The ID of the exception.
        /// </summary>
        public string ExceptionLogId { get; set; }

        /// <summary>
        /// Additional data associated with the exception.
        /// </summary>
        public Dictionary<string, string> Data { get; set; }

        public ExceptionMiddlewareResponse(ExceptionLog exceptionLog)
        {
            Type = exceptionLog.Type;
            ExceptionLogId = exceptionLog.ExceptionLogId.ToString();
            Data = new Dictionary<string, string>
            {
                { "message", exceptionLog.Message }
            };
        }
    }
}
