using Microsoft.AspNetCore.Mvc;
using taskinfinia.Areas.Hrm.Models;
using taskinfinia.Areas.Hrm.Repository;

namespace taskinfinia.Areas.Hrm.Controllers
{
    [Area("Hrm")]
    public class DepartmentController : Controller
    {
       
        public IActionResult department()
        {
            List<DepartmentModel> departmentlist = DepartmentRepository.getdepartment();


            ViewBag.department = departmentlist;
            return View();
        }

        public IActionResult Save(DepartmentModel data)
        {

            int result;
            result = DepartmentRepository.Create(data);
            return Json(result);


        }
    }
}
