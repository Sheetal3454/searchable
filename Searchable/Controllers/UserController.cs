using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Searchable.Data;
using Searchable.Models;
using Sheetal.Requirement;


namespace Searchable.Controllers
{
    public class UserController : Controller
    {
        private readonly TaskDbContext _context;
        public UserController(TaskDbContext context)
        {
            _context = context;

            
        }

        
        public IActionResult Index(int pg=1,string sortExpression="")
        {
            


            const int pageSize = 3;
            if (pg < 1)
                pg = 1;

            int recsCount = _context.Users.Count();

            var pager = new Pager(recsCount,pg,pageSize);

            int recsSkip=(pg-1)*pageSize;

            List<User> users = _context.Users.Skip(recsSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            SortModel sortModel = new SortModel();
            sortModel.AddColumn("UserId");
            sortModel.AddColumn("UserName");
            sortModel.AddColumn("Email");
            sortModel.AddColumn("Password");

            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;

            return View(users);
        }

        [HttpGet]
        public IActionResult Edit(string Id) 
        {   
            User user = _context.Users.Where(p=>p.UserId == Id).FirstOrDefault();
            return View(user);
        }


        [HttpPost]
        public IActionResult Edit(User user)
        {
            _context.Attach(user);
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(string Id)
        {
            User user = _context.Users.Where(p => p.UserId == Id).FirstOrDefault();
            return View(user);
        }


        [HttpPost]
        public IActionResult Delete(User user)
        {
            _context.Attach(user);
            _context.Entry(user).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Create()
        {
            User user = new User();
            return View(user);
 
        }

        public IActionResult Create(User user)
        {
            var userid = _context.Users.Max(uid => uid.UserId);
            long userNo;

            long.TryParse(userid.Substring(2, userid.Length - 2), out userNo);
            if (userNo >0)
            {
                userNo = userNo + 1;
                userid = "CS" + userNo.ToString();

                
            }

            user.UserId = userid;
            _context.Attach(user);
            _context.Entry(user).State = EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
