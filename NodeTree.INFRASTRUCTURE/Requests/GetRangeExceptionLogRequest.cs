using System.ComponentModel;

namespace NodeTree.INFRASTRUCTURE.Requests
{
    /// <summary>
    /// Request object used to retrieve a range of exception logs based on date and/or search criteria.
    /// </summary>
    public class GetRangeExceptionLogRequest
    {
        private string _search;

        /// <summary>
        /// The starting date of the range of exception logs to retrieve.
        /// </summary>
        public DateTime From { get; set; }

        /// <summary>
        /// The ending date of the range of exception logs to retrieve.
        /// </summary>

        public DateTime To { get; set; }

        /// <summary>
        /// The search string to use when filtering exception logs.
        /// </summary>
        [DefaultValue("SecureException")]
        public string Search
        {
            get => _search;
            set => _search = value?.Trim().ToLower();
        }
    }
}
