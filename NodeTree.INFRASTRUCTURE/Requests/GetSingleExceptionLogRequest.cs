using System.ComponentModel;

namespace NodeTree.INFRASTRUCTURE.Requests
{
    /// <summary>
    /// Represents a request to get a single exception log by event ID.
    /// </summary>
    public class GetSingleExceptionLogRequest
    {

        /// <summary>
        /// The ID of the exception log to retrieve.
        /// </summary>
        [DefaultValue(2)]
        public long EventId { get; set; }
    }
}
