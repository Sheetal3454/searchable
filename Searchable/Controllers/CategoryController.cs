using Microsoft.AspNetCore.Mvc;
using Searchable.Data;
using Searchable.Models;

namespace Searchable.Controllers
{
    public class CategoryController : Controller
    {
        private readonly TaskDbContext context;

        public CategoryController(TaskDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {

            var catData = context.Categories.ToList();

            return View(catData);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                var categ = new Category()
                {
                    CategoryName = model.CategoryName,
                    CreatedBy = model.CreatedBy,
                    CreatedDate = model.CreatedDate,
                    ModifiedBy = model.ModifiedBy,
                    ModifiedDate = model.ModifiedDate,

                };
                context.Categories.Add(categ);
                context.SaveChanges();
                TempData["error"] = "Record Saved";
                return RedirectToAction("Index");
            }

            else
            {
                TempData["message"] = "Empty field cannot Submit";
                return View(model);
            }


        }
        public IActionResult Delete(int id)
        {
            var categ = context.Categories.SingleOrDefault(d => d.CategoryId == id);
            context.Categories.Remove(categ);
            context.SaveChanges();
            TempData["error"] = "Record Deleted";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var categ = context.Categories.SingleOrDefault(c => c.CategoryId == id);
            var result = new Category()
            {
                CategoryName = categ.CategoryName,
                CreatedBy = categ.CreatedBy,
                CreatedDate = categ.CreatedDate,
                ModifiedBy = categ.ModifiedBy,
                ModifiedDate = categ.ModifiedDate,

            };
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Category model)
        {
            var categ = new Category()
            {
                CategoryId = model.CategoryId,
                CategoryName = model.CategoryName,
                CreatedBy = model.CreatedBy,
                CreatedDate = model.CreatedDate,
                ModifiedBy = model.ModifiedBy,
                ModifiedDate = model.ModifiedDate,
            };
            context.Categories.Update(categ);
            context.SaveChanges();
            TempData["error"] = "Record updated";

            return RedirectToAction("Index");
        }
    }
}
