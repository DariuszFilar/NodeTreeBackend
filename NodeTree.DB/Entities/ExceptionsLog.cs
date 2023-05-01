namespace NodeTree.DB.Entities
{
    public class ExceptionLog
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public Dictionary<string, string> QueryParameters { get; set; }
        public Dictionary<string, string> BodyParameters { get; set; }
        public string StackTrace { get; set; }
        public string Message { get; set; }
    }
}
