using Microsoft.AspNetCore.Mvc;

namespace SD18406.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
