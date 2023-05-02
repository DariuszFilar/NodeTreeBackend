using NodeTree.DB.Entities;

namespace NodeTree.INFRASTRUCTURE.Responses
{
    /// <summary>
    /// Represents the response returned by the GetSingleExceptionLogRequest.
    /// </summary>
    public class GetSingleExceptionLogResponse
    {
        /// <summary>
        /// Gets or sets the ID of the exception log.
        /// </summary>
        public long ExceptionLogId { get; set; }

        /// <summary>
        /// Gets or sets the type of the exception.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the data of the exception.
        /// </summary>
        public Dictionary<string, string> Data { get; set; }

        /// <summary>
        /// Gets or sets the creation date and time of the exception log.
        /// </summary>
        public DateTime CreatedAt { get; set; }
        public GetSingleExceptionLogResponse(ExceptionLog exceptionLog)
        {
            Type = exceptionLog.Type;
            ExceptionLogId = exceptionLog.ExceptionLogId;
            Data = new Dictionary<string, string>
            {
                { "text", exceptionLog.StackTrace }
            };
            CreatedAt = exceptionLog.CreatedAt;
        }
    }
}

