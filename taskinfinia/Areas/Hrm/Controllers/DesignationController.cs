using Microsoft.AspNetCore.Mvc;
using taskinfinia.Areas.Hrm.Models;
using taskinfinia.Areas.Hrm.Repository;

namespace taskinfinia.Areas.Hrm.Controllers
{
    [Area("Hrm")]
    public class DesignationController : Controller
    {
        public IActionResult designation()
        {
            List<DesignationModel> designationlist = DesignationRepository.getdesignation();


            ViewBag.designation = designationlist;
            return View();
        }

        public IActionResult Save(DesignationModel data)
        {

            int result;
            result = DesignationRepository.Create(data);
            return Json(result);


        }
    }
}
