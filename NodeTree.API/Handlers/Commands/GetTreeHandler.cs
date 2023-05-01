using NodeTree.DB.Entities;
using NodeTree.INFRASTRUCTURE.Requests;
using NodeTree.INFRASTRUCTURE.Responses;
using NodeTree.INFRASTRUCTURE.Services.Abstract;

namespace NodeTree.API.Handlers.Commands
{
    public class GetTreeHandler : IRequestHandler<GetTreeRequest, GetTreeResponse>
    {
        private readonly ITreeService _treeService;
        public GetTreeHandler(ITreeService treeService)
        {
            _treeService = treeService;
        }
        public async Task<GetTreeResponse> Handle(GetTreeRequest request)
        {
            Node tree = await _treeService.GetTreeAsync(request.TreeName);
            return new GetTreeResponse(tree);
        }
    }
}
