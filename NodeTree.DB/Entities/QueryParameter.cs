namespace NodeTree.DB.Entities
{
    public class QueryParameter
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public long ExceptionLogId { get; set; }
        public virtual ExceptionLog ExceptionLog { get; set; }
    }

}
