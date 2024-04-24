using Microsoft.AspNetCore.Mvc;

namespace taskinfinia.Areas.Hrm.Controllers
{
    [Area("Hrm")]
    public class EmployeeController : Controller
    {
        public IActionResult employee()
        {
            return View();
        }
    }
}
