using System.ComponentModel;

namespace NodeTree.INFRASTRUCTURE.Requests
{
    /// <summary>
    /// Request model for creating a new node.
    /// </summary>
    public class CreateNodeRequest
    {
        /// <summary>
        /// The ID of the parent node for the new node.
        /// </summary>
        [DefaultValue("2")]
        public long ParentId { get; set; }

        /// <summary>
        /// The name of the new node.
        /// </summary>
        [DefaultValue("Example Node")]
        public string NodeName { get; set; }

        /// <summary>
        /// The name of the tree that the new node belongs to.
        /// </summary>
        [DefaultValue("Example Tree Name")]
        public string TreeName { get; set; }
    }
}
