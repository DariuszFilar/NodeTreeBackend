namespace NodeTree.DB.Entities
{
    public class Node
    {
        public long Id { get; set; }
        public long ParentId { get; set; }
        public string Name { get; set; }
    }
}
