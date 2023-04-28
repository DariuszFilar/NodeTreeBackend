using Microsoft.AspNetCore.Mvc;
using NodeTree.API.Handlers.Commands;
using NodeTree.INFRASTRUCTURE.Requests;
using NodeTree.INFRASTRUCTURE.Responses;

namespace NodeTree.API.Controllers
{
    [ApiController]
    [Route("api.user.tree")]
    public class NodeController : Controller
    {
        private readonly IRequestHandler<CreateNodeRequest, CreateNodeResponse> _createNodeHandler;
        private readonly IRequestHandler<DeleteNodeRequest, DeleteNodeResponse> _deleteNodeHandler;
        private readonly IRequestHandler<RenameNodeRequest, RenameNodeResponse> _renameNodeHandler;

        public NodeController(IRequestHandler<CreateNodeRequest, CreateNodeResponse> createNodeHandler, 
            IRequestHandler<DeleteNodeRequest, DeleteNodeResponse> deleteNodeHandler,
            IRequestHandler<RenameNodeRequest, RenameNodeResponse> requestHandler)
        {
            _createNodeHandler = createNodeHandler;
            _deleteNodeHandler = deleteNodeHandler;
            _renameNodeHandler = requestHandler;
        }

        [HttpPost("node.add")]
        public async Task<IActionResult> AddNode(CreateNodeRequest request)
        {
            var response = await _createNodeHandler.Handle(request);
            return Ok(response);
        }

        [HttpPost("node.delete")]
        public async Task<IActionResult> DeleteNode(DeleteNodeRequest request)
        {
            var response = await _deleteNodeHandler.Handle(request);
            return Ok(response);
        }

        [HttpPost("node.rename")]
        public async Task<IActionResult> UpdateNode(RenameNodeRequest request)
        {
            var response = await _renameNodeHandler.Handle(request);
            return Ok(response);
        }
    }
}
