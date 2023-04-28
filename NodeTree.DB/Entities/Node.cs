namespace NodeTree.DB.Entities
{
    public class Node
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public virtual List<Node> Children { get; set; }
    }
}
