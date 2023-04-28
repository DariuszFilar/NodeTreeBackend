using NodeTree.DB.Entities;

namespace NodeTree.INFRASTRUCTURE.DTOs
{
    public class GetTreeDtos
    {
        public class GetTreeDto
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public virtual IEnumerable<GetTreeDto> Children { get; set; }

            public GetTreeDto(Node node)
            {
                Id = node.NodeId;
                Name = node.Name;
                Children = node.Children.Select(n => new GetTreeDto(n));
            }
        }
    }
}
