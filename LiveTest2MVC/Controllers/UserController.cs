using LiveTest2MVC.Data;
using LiveTest2MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LiveTest2MVC.Controllers
{
    public class UserController : Controller
    {

        private readonly UserDbContext _context;
        public UserController(UserDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(string userRole)
        {
            IQueryable<User> query = _context.Users;
            ViewBag.userRole = userRole;
            if (!string.IsNullOrEmpty(userRole))
            {
                query = query.Where(d => d.Role.ToString() == userRole);
            }
            var users = query.ToList();
            
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {

            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction ("Index");
            }
            return View();
        }
    }
}
