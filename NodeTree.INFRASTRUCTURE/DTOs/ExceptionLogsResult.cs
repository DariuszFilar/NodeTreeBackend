using NodeTree.DB.Entities;

namespace NodeTree.INFRASTRUCTURE.DTOs
{
    /// <summary>
    /// Represents the result of a query for exception logs in the system.
    /// </summary>
    public class ExceptionLogResult
    {
        /// <summary>
        /// The total count of exception logs matching the query.
        /// </summary>
        public long Count { get; set; }

        /// <summary>
        /// The list of exception logs matching the query.
        /// </summary>
        public List<ExceptionLog> ExceptionLogs { get; set; }
    }

}
