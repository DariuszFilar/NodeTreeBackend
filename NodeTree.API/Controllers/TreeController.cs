using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NodeTree.API.Handlers;
using NodeTree.INFRASTRUCTURE.Requests;
using NodeTree.INFRASTRUCTURE.Responses;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(
            Summary = "Returns entire tree.",
            Description = "Returns entire tree. If tree doesn't exist it will be created automatically."
            )]
        public async Task<IActionResult> GetTreeAsync(GetTreeRequest request) 
        {
            var response = await _getTreeHandler.Handle(request);
            return Ok(response);
        }
    }
}
