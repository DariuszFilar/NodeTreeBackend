namespace NodeTree.DB.Entities
{
    public class Node
    {
        public long Id { get; set; }        
        public string Name { get; set; }
        public List<Node> Children { get; set; }
    }
}
