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

        [HttpPost]

        public ActionResult Delete(int id)
        {
            int result;
            result = ItemRepository.deleteitem(id);

            return Json(new { success = true, Message = "Delete Successfully!" });
        }


        [HttpGet("Item/Edit/{stk_id}")]
        public ActionResult Edit(int stk_id)
        {
            //data show on edit page .placeholder
            ItemModel data = ItemRepository.GetItemlistData(stk_id);

            return View(data);
        }

        [HttpPost]
        public ActionResult update(ItemModel data)
        {
            int result;
            result = ItemRepository.Update(data);


            return Json(result);

        }
    }
}
