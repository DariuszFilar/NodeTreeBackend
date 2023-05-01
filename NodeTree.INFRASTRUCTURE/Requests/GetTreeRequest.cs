using System.ComponentModel;

namespace NodeTree.INFRASTRUCTURE.Requests
{
    /// <summary>
    /// Represents a request to get a tree by its name.
    /// </summary>
    public class GetTreeRequest
    {
        /// <summary>
        /// Gets or sets the name of the tree to retrieve.
        /// </summary>
        [DefaultValue("Tree Name")]
        public string TreeName { get; set; }
    }
}
