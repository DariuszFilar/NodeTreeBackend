using NodeTree.DB.Entities;
using static NodeTree.INFRASTRUCTURE.DTOs.GetTreeDtos;

namespace NodeTree.INFRASTRUCTURE.Responses
{
    public class GetTreeResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<GetTreeResponse> Children { get; set; }

        public GetTreeResponse(Node node)
        {
            Id = node.NodeId;
            Name = node.Name;
            Children = node.Children?.Select(child => new GetTreeResponse(child));
        }
    }
}
