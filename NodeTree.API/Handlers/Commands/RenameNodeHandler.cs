using NodeTree.INFRASTRUCTURE.Requests;
using NodeTree.INFRASTRUCTURE.Responses;
using NodeTree.INFRASTRUCTURE.Services.Abstract;

namespace NodeTree.API.Handlers.Commands
{
    public class RenameNodeHandler : IRequestHandler<RenameNodeRequest, RenameNodeResponse>
    {
        private readonly INodeService _nodeService;
        public RenameNodeHandler(INodeService nodeService)
        {
            _nodeService = nodeService;
        }
        public async Task<RenameNodeResponse> Handle(RenameNodeRequest request)
        {
            await _nodeService.RenameNodeAsync(request);

            return new RenameNodeResponse();
        }
    }
}
