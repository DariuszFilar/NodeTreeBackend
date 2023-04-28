using Microsoft.AspNetCore.Mvc;
using NodeTree.API.Handlers.Commands;
using NodeTree.INFRASTRUCTURE.Requests;
using NodeTree.INFRASTRUCTURE.Responses;

namespace NodeTree.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NodeController : Controller
    {
        private readonly IRequestHandler<CreateNodeRequest, CreateNodeResponse> _createNodeHandler;
        private readonly IRequestHandler<DeleteNodeRequest, DeleteNodeResponse> _deleteNodeHandler;

        public NodeController(IRequestHandler<CreateNodeRequest, CreateNodeResponse> createNodeHandler, 
            IRequestHandler<DeleteNodeRequest, DeleteNodeResponse> deleteNodeHandler)
        {
            _createNodeHandler = createNodeHandler;
            _deleteNodeHandler = deleteNodeHandler;
        }

        [HttpPost("add-node")]
        public async Task<IActionResult> AddNode(CreateNodeRequest request)
        {
            var response = await _createNodeHandler.Handle(request);
            return Ok(response);
        }

        [HttpPost("delete-node")]
        public async Task<IActionResult> DeleteNode(DeleteNodeRequest request)
        {
            var response = await _deleteNodeHandler.Handle(request);
            return Ok(response);
        }
    }
}
