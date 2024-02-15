using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Searchable.Data;
using Searchable.Models;
using Searchable.Models.ViewModel;

namespace Searchable.Controllers
{
    public class TaskController : Controller
    {
        private readonly TaskDbContext context;

        public TaskController(TaskDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {

            var data = from t in context.Tassks
                       join u in context.Users on t.UserId equals u.UserId
                       join c in context.Categories on t.CategoryId equals c.CategoryId
                       select new TasskSummaryView
                       {
                           TaskId = t.TaskId,
                           Title = t.Title,
                           Description = t.Description,
                           DueDate = t.DueDate,
                           IsCompleted = t.IsCompleted,
                           UserId = u.UserId,

                           CategoryId = c.CategoryId,

                       };

            return View(data);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(Tassk model)
        {
            if (ModelState.IsValid)
            {
                var tas = new Tassk()
                {
                    Title = model.Title,
                    Description = model.Description,
                    DueDate = model.DueDate,
                    IsCompleted = model.IsCompleted,
                    UserId = model.UserId,
                    CategoryId = model.CategoryId,

                };
                context.Tasks.Add(tas);
                context.SaveChanges();
                TempData["error"] = "Record Saved";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = "Empty Field cannpt Submitted";
                return View(model);
            }
        }

        public IActionResult Delete(int id)
        {
            var tas = context.Tasks.SingleOrDefault(b => b.TaskId == id);
            context.Tasks.Remove(tas);
            context.SaveChanges();
            TempData["error"] = "Record Deleted";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var tas = context.Tasks.SingleOrDefault(b => b.TaskId == id);
            var result = new Tassk()
            {
                Title = tas.Title,
                Description = tas.Description,
                DueDate = tas.DueDate,
                IsCompleted = tas.IsCompleted,
                UserId = tas.UserId,
                CategoryId = tas.CategoryId,


            };
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Tassk model)
        {
            var tas = new Tassk()
            {
                TaskId = model.TaskId,
                Title = model.Title,
                Description = model.Description,
                DueDate = model.DueDate,
                IsCompleted = model.IsCompleted,
                UserId = model.UserId,
                CategoryId = model.CategoryId,


            };
            context.Tasks.Update(tas);
            context.SaveChanges();
            TempData["error"] = "Record updated";

            return RedirectToAction("Index");
        }
    }
}