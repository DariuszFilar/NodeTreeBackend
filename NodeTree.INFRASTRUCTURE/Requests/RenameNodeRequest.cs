using System.ComponentModel;

namespace NodeTree.INFRASTRUCTURE.Requests
{
    /// <summary>
    /// Represents a request to rename a node in a tree.
    /// </summary>
    public class RenameNodeRequest
    {
        /// <summary>
        /// The ID of the node to be renamed.
        /// </summary>
        [DefaultValue(2)]
        public long NodeId { get; set; }

        /// <summary>
        /// The new name for the node.
        /// </summary>
        [DefaultValue("New Name")]
        public string NewNodeName { get; set; }

        /// <summary>
        /// The name of the tree that the node belongs to.
        /// </summary>
        [DefaultValue("Name of the Tree")]
        public string TreeName { get; set; }
    }
}
