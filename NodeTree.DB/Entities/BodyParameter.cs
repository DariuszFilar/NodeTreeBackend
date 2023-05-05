namespace NodeTree.DB.Entities
{
    /// <summary>
    /// Represents a body parameter entity for body parameters that occur in exception in the system.
    /// </summary>
    public class BodyParameter
    {
        /// <summary>
        /// The unique identifier of the body parameter.
        /// </summary>  
        /// <param name="Id">The value of the unique identifier.</param>
        public int Id { get; set; }

        /// <summary>
        /// The key of the body parameter.
        /// </summary>  
        /// <param name="Key">The value of the key.</param>
        public string Key { get; set; }

        /// <summary>
        /// The value of the body parameter.
        /// </summary> 
        /// <param name="Value">The value of the body parameter.</param>
        public string Value { get; set; }

        /// <summary>
        /// The unique identifier of the exception log associated with this body parameter.
        /// </summary>  
        /// <param name="ExceptionLogId">The value of the unique identifier of the exception log.</param>
        public long ExceptionLogId { get; set; }

        /// <summary>
        /// The exception log associated with this body parameter.
        /// </summary>  
        /// <param name="ExceptionLog">The value of the exception log.</param>
        public virtual ExceptionLog ExceptionLog { get; set; }
    }
}
