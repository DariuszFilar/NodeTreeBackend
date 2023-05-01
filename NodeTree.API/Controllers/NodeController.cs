using Microsoft.AspNetCore.Mvc;
using NodeTree.API.Handlers;
using NodeTree.INFRASTRUCTURE.Requests;
using NodeTree.INFRASTRUCTURE.Responses;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(
            Summary = "Adds a new node to the tree",    
            Description = "Adds a new node to the tree at the specified location, with the provided name"
            )]
        public async Task<IActionResult> AddNode(CreateNodeRequest request)
        {
            var response = await _createNodeHandler.Handle(request);
            return Ok(response);
        }

        [SwaggerOperation(
            Summary = "Deletes a node from the tree.",
            Description = "Deletes a node with the specified ID from the tree."
            )]
        [HttpPost("node.delete")]
        public async Task<IActionResult> DeleteNode(DeleteNodeRequest request)
        {
            var response = await _deleteNodeHandler.Handle(request);
            return Ok(response);
        }

        [SwaggerOperation(
           Summary = "Updates the name of a node in the tree.",
           Description = "Rename a node with the specified ID from the tree."
           )]
        [HttpPost("node.rename")]
        public async Task<IActionResult> UpdateNode(RenameNodeRequest request)
        {
            var response = await _renameNodeHandler.Handle(request);
            return Ok(response);
        }
    }
}
