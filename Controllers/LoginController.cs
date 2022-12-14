using Microsoft.AspNetCore.Mvc;

namespace apka2.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
