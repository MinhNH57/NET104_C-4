using DeThiThuLan1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace DeThiThuLan1.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly DonHangDbContext _db;

        public KhachHangController(DonHangDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var kh = _db.KhachHangs.ToList();
            return View(kh);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(KhachHang kh)
        {
            _db.KhachHangs.Add(kh);
            _db.SaveChanges();
            return RedirectToAction("Index", "KhachHang");
        }

        public IActionResult Update(Guid id)
        {
            var k = _db.KhachHangs.Find(id);
            var khJson = JsonConvert.SerializeObject(k);
            HttpContext.Session.SetString("KhachHangRollBack", khJson);
            return View(k);
        }

        [HttpPost]
        public IActionResult Update(KhachHang kh)
        {
            _db.KhachHangs.Update(kh);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var k = _db.KhachHangs.Find(id);
            _db.KhachHangs.Remove(k);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult RollBack()
        {
            var s = HttpContext.Session.GetString("KhachHangRollBack");
            if(s != null)
            {
                var kh = JsonConvert.DeserializeObject<KhachHang>(s);
                _db.KhachHangs.Update(kh);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult Details(Guid id)
        {
            var s = _db.KhachHangs.Find(id);
            return View(s);
        }
    }
}
