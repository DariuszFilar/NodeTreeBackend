namespace NodeTree.INFRASTRUCTURE.Requests
{
    public class RenameNodeRequest
    {
        public long NodeId { get; set; }
        public string NewNodeName { get; set; }
        public string TreeName { get; set; }
    }
}
