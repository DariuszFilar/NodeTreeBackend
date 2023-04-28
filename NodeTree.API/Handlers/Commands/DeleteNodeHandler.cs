using NodeTree.INFRASTRUCTURE.Requests;
using NodeTree.INFRASTRUCTURE.Responses;
using NodeTree.INFRASTRUCTURE.Services.Abstract;

namespace NodeTree.API.Handlers.Commands
{
    public class DeleteNodeHandler : IRequestHandler<DeleteNodeRequest, DeleteNodeResponse>
    {
        private readonly INodeService _nodeService;
        public DeleteNodeHandler(INodeService nodeService)
        {
            _nodeService = nodeService;
        }
        public async Task<DeleteNodeResponse> Handle(DeleteNodeRequest request)
        {
            await _nodeService.DeleteNodeAsync(request);

            return new DeleteNodeResponse();
        }
    }
}
