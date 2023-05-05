namespace NodeTree.DB.Entities
{
    /// <summary>
    /// Represents a log entity for exceptions that occur in the system.
    /// </summary>
    public class ExceptionLog
    {
        /// <summary>
        /// The unique identifier of the exception log.
        /// </summary>  
        /// <param name="exceptionLogId">The value of the unique identifier.</param>
        public long ExceptionLogId { get; set; }

        /// <summary>
        /// The type of the exception.
        /// </summary>
        /// <param name="type">The value of the type.</param>
        public string Type { get; set; }

        /// <summary>
        /// The timestamp when the exception occurred.
        /// </summary>
        /// <param name="createdAt">The value of the timestamp.</param>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The stack trace of the exception.
        /// </summary>
        /// <param name="stackTrace">The value of the stack trace.</param>
        public string StackTrace { get; set; }

        /// <summary>
        /// The error message associated with the exception.
        /// </summary>
        /// <param name="message">The value of the error message.</param>
        public string Message { get; set; }

        /// <summary>
        /// The body parameters associated with the exception.
        /// </summary>
        /// <param name="bodyParameters">The value of the body parameters.</param>
        public virtual ICollection<BodyParameter> BodyParameters { get; set; }

        /// <summary>
        /// The query parameters associated with the exception.
        /// </summary>
        /// <param name="bodyParameters">The value of the body parameters.</param>
        public virtual ICollection<QueryParameter> QueryParameters { get; set; }
    }
}
