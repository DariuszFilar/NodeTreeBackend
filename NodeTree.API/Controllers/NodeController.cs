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

        public NodeController(IRequestHandler<CreateNodeRequest, CreateNodeResponse> createNodeHandler)
        {
            _createNodeHandler = createNodeHandler;
        }

        [HttpPost("add-node")]
        public async Task<IActionResult> AddNode(CreateNodeRequest request)
        {
            var response = await _createNodeHandler.Handle(request);
            return Ok(response);
        }
       
    }
}
