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
        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            
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
