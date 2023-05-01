namespace NodeTree.INFRASTRUCTURE.DTOs
{
    /// <summary>
    /// Represents the response data transfer object for an exception log in the system.
    /// </summary>
    public class ExcetpionLogResponseDto
    {
        /// <summary>
        /// The unique identifier of the exception log.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The timestamp when the exception occurred.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
