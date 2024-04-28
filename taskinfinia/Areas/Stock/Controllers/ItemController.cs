using Microsoft.AspNetCore.Mvc;
using taskinfinia.Areas.Stock.Models;
using taskinfinia.Areas.Stock.Repository;

namespace taskinfinia.Areas.Stock.Controllers
{
    [Area("Stock")]
    public class ItemController : Controller
    {
        public IActionResult Additem()
        {
            return View();
        }

        public IActionResult Save(ItemModel data)
        {
            int result;
            result = ItemRepository.Create(data);
            return Json(result);
        }

        public IActionResult Itemlist()
        {
            List<ItemModel> itemlist = ItemRepository.GetItemList();


            ViewBag.item = itemlist;
            return View();
        }
    }
}
