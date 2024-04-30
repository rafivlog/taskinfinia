using Microsoft.AspNetCore.Mvc;
using taskinfinia.Areas.Stock.Models;
using taskinfinia.Areas.Stock.Repository;

namespace taskinfinia.Areas.Stock.Controllers
{
    [Area("Stock")]
    public class DistributedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Distitem()
        {
            return View();
        }

        //public IActionResult GetItemDropdownData(int id)
        //{

        //    IEnumerable<itemdropdownModel> data = DistributedRepository.GetDropDownData(id);
        //    return Json(data);
        //}




        public IActionResult Save(DistributedModel data)
        {

            int result;
            result = DistributedRepository.Create(data);


            return Json(result);


        }

        public IActionResult Show()
        {
            List<DistributedModel> distlist = DistributedRepository.GetDistributedList();


            ViewBag.dist = distlist;
            return View();
        }

    }
}
