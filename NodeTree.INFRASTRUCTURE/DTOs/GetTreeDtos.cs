using NodeTree.DB.Entities;

namespace NodeTree.INFRASTRUCTURE.DTOs
{
    /// <summary>
    /// Represents the data transfer object for a tree node and its children.
    /// </summary>
    public class GetTreeDto
    {
        /// <summary>
        /// The unique identifier of the node.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The name of the node.
        /// </summary>

        public string Name { get; set; }

        /// <summary>
        /// The children nodes of the current node.
        /// </summary>
        public virtual IEnumerable<GetTreeDto> Children { get; set; }

        public GetTreeDto(Node node)
        {
            Id = node.NodeId;
            Name = node.Name;
            Children = node.Children.Select(n => new GetTreeDto(n));
        }
    }

}
