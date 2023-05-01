using NodeTree.DB.Entities;

namespace NodeTree.INFRASTRUCTURE.DTOs
{
    public class ExceptionLogResult
    {
        public long Count { get; set; }
        public List<ExceptionLog> ExceptionLogs { get; set; }
    }

}
