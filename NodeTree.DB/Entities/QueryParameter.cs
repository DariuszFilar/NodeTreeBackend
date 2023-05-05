namespace NodeTree.DB.Entities
{
    /// <summary>
    /// Represents a query parameter entity for query parameters that occur in an exception in the system.
    /// </summary>
    public class QueryParameter
    {
        /// <summary>
        /// The unique identifier of the query parameter.
        /// </summary> 
        /// <param name="Key">The value of the key.</param> 
        public int Id { get; set; }

        /// <summary>
        /// The key of the query parameter.
        /// </summary>  
        /// <param name="Value">The value of the query parameter.</param>
        public string Key { get; set; }

        /// <summary>
        /// The value of the query parameter.
        /// </summary>  
        public string Value { get; set; }

        /// <summary>
        /// The unique identifier of the exception log associated with this query parameter.
        /// </summary>         
        /// <param name="ExceptionLogId">The value of the unique identifier of the exception log.</param> 
        public long ExceptionLogId { get; set; }

        /// <summary>
        /// The exception log associated with this query parameter.
        /// </summary>  
        /// <param name="ExceptionLog">The value of the exception log.</param> 
        public virtual ExceptionLog ExceptionLog { get; set; }
    }

}
