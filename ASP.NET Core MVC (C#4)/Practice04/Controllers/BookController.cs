using Microsoft.AspNetCore.Mvc;
using Practice04.Models;

namespace Practice04.Controllers
{
    public class BookController : Controller
    {
        private readonly BookDbContext _db;

        public BookController(BookDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var m = _db.books.ToList();
            return View(m);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book b)
        {
            _db.books.Add(b);
            _db.SaveChanges();
            return RedirectToAction("Index", "Book");
        }
    }
}
