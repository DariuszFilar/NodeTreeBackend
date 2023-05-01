namespace NodeTree.DB.Entities
{
    /// <summary>
    /// Represents a node entity in the tree structure.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// The unique identifier of the node.
        /// </summary>
        /// <param name="nodeId">The value of the unique identifier.</param> 
        public long NodeId { get; set; }

        /// <summary>
        /// The name of the node.
        /// </summary>
        /// <param name="name">The value of the name.</param>
        public string Name { get; set; }

        /// <summary>
        /// The unique identifier of the parent node.
        /// </summary>
        /// <param name="parentId">The value of the unique identifier of the parent node.</param>
        public long? ParentId { get; set; }

        /// <summary>
        /// The parent of node.
        /// </summary>
        /// <param name="parent">The value of the parent node.</param>
        public virtual Node Parent { get; set; }

        /// <summary>
        /// The collection of child nodes.
        /// </summary>
        /// <param name="children">The collection of child nodes.</param>
        public virtual ICollection<Node> Children { get; set; }

        /// <summary>
        /// The name of the tree the node belongs to.
        /// </summary>
        /// <param name="treeName">The value of the tree name.</param>
        public string TreeName { get; set; }
    }
}
