using Microsoft.AspNetCore.Mvc;
using taskinfinia.Areas.Hrm.Models;
using taskinfinia.Areas.Hrm.Repository;

namespace taskinfinia.Areas.Hrm.Controllers
{
    [Area("Hrm")]
    public class EmployeeController : Controller
    {
        public IActionResult employee()
        {
            return View();
        }

        public IActionResult Save(EmployeeModel data)
        {

            int result;
            result = EmployeeRepository.Create(data);


            return Json(result);

        }

        public IActionResult emplist()
        {
            List<EmployeeModel> emplist = EmployeeRepository.getemployeelist();
            ViewBag.employee = emplist;
            return View();
        }
    }
}
