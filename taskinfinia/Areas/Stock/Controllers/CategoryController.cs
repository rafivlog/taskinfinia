using Microsoft.AspNetCore.Mvc;
using taskinfinia.Areas.Hrm.Models;
using taskinfinia.Areas.Hrm.Repository;
using taskinfinia.Areas.Stock.Models;
using taskinfinia.Areas.Stock.Repository;

namespace taskinfinia.Areas.Stock.Controllers
{
    [Area("Stock")]
    public class CategoryController : Controller
    {
       

        public IActionResult category()
        {
            List<CategoryModel> categorylist = CategoryRepository.getcategory();


            ViewBag.category = categorylist;

            return View();
        }

        public IActionResult Save(CategoryModel data)
        {

            int result;
            result = CategoryRepository.Create(data);
            return Json(result);


        }

        [HttpGet("Category/Edit/{cat_id}")]
        public ActionResult Edit(int cat_id)
        {
            //data show on edit page .placeholder
            CategoryModel data = CategoryRepository.GetEditCategoryData(cat_id);



            return View(data);
        }

        [HttpPost]
        public ActionResult update(CategoryModel data)
        {
            int result;
            result = CategoryRepository.Update(data);


            return Json(result);

        }

        [HttpPost]

        public ActionResult Delete(int id)
        {
            int result;
            result = CategoryRepository.deleteCategory(id);
            //return Json(result);

            return Json(new { success = true, Message = "Delete Successfully!" });
        }

    }
}
