using Microsoft.AspNetCore.Mvc;

namespace AdmonStore.Api2.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
