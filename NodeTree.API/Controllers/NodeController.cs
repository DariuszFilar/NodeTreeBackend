using Microsoft.AspNetCore.Mvc;

namespace NodeTree.API.Controllers
{
    public class NodeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
