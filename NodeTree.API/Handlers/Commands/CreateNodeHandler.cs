using NodeTree.INFRASTRUCTURE.Requests;
using NodeTree.INFRASTRUCTURE.Responses;
using NodeTree.INFRASTRUCTURE.Services.Abstract;

namespace NodeTree.API.Handlers.Commands
{
    public class CreateNodeHandler : IRequestHandler<CreateNodeRequest, CreateNodeResponse>
    {
        private readonly INodeService _nodeService;
        public CreateNodeHandler(INodeService nodeService)
        {
            _nodeService = nodeService;
        }
        public async Task<CreateNodeResponse> Handle(CreateNodeRequest request)
        {
            await _nodeService.CreateNodeAsync(request);

            return new CreateNodeResponse();
        }
    }
}
