namespace NodeTree.INFRASTRUCTURE.Requests
{
    public class GetRangeExceptionLogRequest
    {
        private string _search;
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Search
        {
            get => _search;
            set => _search = value?.Trim().ToLower();
        }
    }
}
