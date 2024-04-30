using Microsoft.AspNetCore.Mvc;
using taskinfinia.Areas.Stock.Models;
using taskinfinia.Areas.Stock.Repository;

namespace taskinfinia.Areas.Stock.Controllers
{
    [Area("Stock")]
    public class DropDownController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCategoryDropDownData()
        {
            IEnumerable<DropDownModel> data = DropDownRepository.GetCategoryName();
            return Json(data);
        }
        public IActionResult GetItemnameAndQuantity(int id)
        {
            IEnumerable<DropDownModel> data = DropDownRepository.GetItemAndQuantity(id);
            return Json(data);
        }
       
    }
}
