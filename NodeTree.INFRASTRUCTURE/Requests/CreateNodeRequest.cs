namespace NodeTree.INFRASTRUCTURE.Requests
{
    public class CreateNodeRequest
    {
        public long ParentId { get; set; }
        public string NodeName { get; set; }
        public string TreeName { get; set; }
    }
}
