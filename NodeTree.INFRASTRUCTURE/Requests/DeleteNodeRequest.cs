using System.ComponentModel;

namespace NodeTree.INFRASTRUCTURE.Requests
{
    /// <summary>
    /// Request object for deleting a node from a tree.
    /// </summary>
    public class DeleteNodeRequest
    {
        /// <summary>
        /// The ID of the node to be deleted.
        /// </summary>
        [DefaultValue(2)]
        public long NodeId { get; set; }

        /// <summary>
        /// The name of the tree that the node belongs to.
        /// </summary>
        [DefaultValue("Example Name")]
        public string TreeName { get; set; }
    }
}
