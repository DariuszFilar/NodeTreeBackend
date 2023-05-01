using NodeTree.DB.Entities;

namespace NodeTree.INFRASTRUCTURE.Responses
{
    /// <summary>
    /// Represents a response object containing a tree node and its children.
    /// </summary>
    public class GetTreeResponse
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
        /// The list of child nodes of this node.
        /// </summary>
        public virtual IEnumerable<GetTreeResponse> Children { get; set; }

        public GetTreeResponse(Node node)
        {
            Id = node.NodeId;
            Name = node.Name;
            Children = node.Children?.Select(child => new GetTreeResponse(child));
        }
    }
}
