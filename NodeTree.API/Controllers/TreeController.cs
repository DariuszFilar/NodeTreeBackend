using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NodeTree.API.Handlers;
using NodeTree.INFRASTRUCTURE.Requests;
using NodeTree.INFRASTRUCTURE.Responses;

namespace NodeTree.API.Controllers
{
    [ApiController]
    [Route("api.user.tree")]
    public class TreeController : ControllerBase
    {
        private readonly IRequestHandler<GetTreeRequest, GetTreeResponse> _getTreeHandler;
        public TreeController(IRequestHandler<GetTreeRequest, GetTreeResponse> getTreeHandler)
        {
            _getTreeHandler = getTreeHandler;
        }
        [HttpPost("get")]
        public async Task<IActionResult> GetTree(GetTreeRequest request) 
        {
            var response = await _getTreeHandler.Handle(request);
            return Ok(response);
        }
    }
}
