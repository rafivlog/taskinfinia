using Microsoft.AspNetCore.Mvc;

namespace taskinfinia.Areas.Stock.Controllers
{
    public class DropDownController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
