namespace NodeTree.DB.Entities
{
    public class Node
    {
        public long NodeId { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public virtual Node Parent { get; set; }
        public virtual ICollection<Node> Children { get; set; }
    }
}
