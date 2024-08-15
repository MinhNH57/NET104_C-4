using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NguyenHongMinh_BaoVeMon.Models;

namespace NguyenHongMinh_BaoVeMon.Controllers
{
    public class CanHoController : Controller
    {
        private readonly MyDBContext _db;

        public CanHoController(MyDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var s = _db.Canhos.ToList();
            return View(s);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CanHo ch)
        {
            _db.Canhos.Add(ch);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(string id)
        {
            var s = _db.Canhos.Find(id);
            var CanHojson = JsonConvert.SerializeObject(s);
            HttpContext.Session.SetString("CanHo", CanHojson);
            return View(s);
        }

        [HttpPost]
        public IActionResult Edit(CanHo ch)
        {
            _db.Canhos.Update(ch);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RollBack()
        {
            var s = HttpContext.Session.GetString("CanHo");
            if (s == null)
            {
                return NotFound();
            }
            else
            {
                var siv = JsonConvert.DeserializeObject<CanHo>(s);
                _db.Canhos.Update(siv);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            var s = _db.Canhos.Find(id);
            var sinhvienjson = JsonConvert.SerializeObject(s);
            HttpContext.Session.SetString("CanHoXoa", sinhvienjson);
            _db.Canhos.Remove(s);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult ReviewData()
        {
            var dataD = HttpContext.Session.GetString("CanHoXoa");
            if (dataD != null)
            {
                var Studeleted = JsonConvert.DeserializeObject<CanHo>(dataD);
                return View("ReviewData", Studeleted);
            }
            else
            {
                return Content("Deo co");
            }
        }

        [HttpPost]
        public IActionResult RollbackDelete()
        {
            var deletedKhachHangJson = HttpContext.Session.GetString("CanHoXoa");

            if (!string.IsNullOrEmpty(deletedKhachHangJson))
            {

                var khachHang = JsonConvert.DeserializeObject<CanHo>(deletedKhachHangJson);


                _db.Canhos.Add(khachHang);
                _db.SaveChanges();


                HttpContext.Session.Remove("CanHoXoa");

                return RedirectToAction("Index");
            }

            return NotFound();
        }

        public IActionResult Details (string id)
        {
            var s = _db.Canhos.Find(id);
            return View(s);
        }
    }
}
