using Microsoft.AspNetCore.Mvc;
using taskinfinia.Areas.Hrm.Models;
using taskinfinia.Areas.Hrm.Repository;

namespace taskinfinia.Areas.Hrm.Controllers
{
    [Area("Hrm")]
    public class DropDownController : Controller
    {
        
        public IActionResult GetdepartmentDropdownData()
        {
            IEnumerable<DropDownModel> data = DropDownRepository.Getdepartment();
            return Json(data);
        }
        public IActionResult GetdesignationDropdownData()
        {
            IEnumerable<DropDownModel> data = DropDownRepository.Getdesignation();
            return Json(data);
        }
        public IActionResult GetemployeeName()
        {
            IEnumerable<DropDownModel> data = DropDownRepository.GetEmployeeName();
            return Json(data);
        }
    }
}
