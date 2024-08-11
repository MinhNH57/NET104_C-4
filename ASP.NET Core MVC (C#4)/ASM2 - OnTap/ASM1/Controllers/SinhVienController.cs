using ASM1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ASM1.Controllers
{
    public class SinhVienController : Controller
    {
        private readonly ASMDbContext _db;
        public SinhVienController(ASMDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var sv = _db.SinhViens.ToList();

            var lopHocs = _db.LopHocs.ToDictionary(l => l.MaLop, l => l.TenLop);
            ViewBag.LopHocs = lopHocs;

            return View(sv);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SinhVien sv)
        {
            _db.SinhViens.Add(sv);
            _db.SaveChanges();
            return RedirectToAction("Index" , "SinhVien");
        }

        public IActionResult Edit(Guid id)
        {
            var up = _db.SinhViens.Find(id);
            if(up == null)
            {
                return NotFound();
            }
            else
            {
                return View(up);    
            }
        }

        [HttpPost]
        public IActionResult Edit(SinhVien sinhv)
        {
            _db.SinhViens.Update(sinhv);
            _db.SaveChanges();
            return RedirectToAction("Index", "SinhVien");
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var d = _db.SinhViens.Find(id);

            var json = JsonConvert.SerializeObject(d);

            HttpContext.Session.SetString("Student" , json);

            _db.SinhViens.Remove(d);
            _db.SaveChanges();
            return RedirectToAction("Index", "SinhVien");
        }

        public IActionResult Details(Guid id)
        {
            var d = _db.SinhViens.Find(id);
            return View(d);
        }

        public IActionResult ReviewData()
        {
            var dataD =  HttpContext.Session.GetString("Student");
            if(dataD != null)
            {
                var Studeleted = JsonConvert.DeserializeObject<SinhVien>(dataD);
                return View("Student_ViewData", Studeleted);
            }
            else
            {
                return Content("Deo co");
            }
        }

        [HttpPost]
        public IActionResult RollBackData()
        {
            if(HttpContext.Session.Keys.Contains("Student"))
            {
                var jsondata = HttpContext.Session.GetString("Student");
                var data = JsonConvert.DeserializeObject<SinhVien>(jsondata);

                _db.SinhViens.Add(data);
                _db.SaveChanges();
                return RedirectToAction("Index" , "SinhVien");
            }
            else
            {
                return Content("No");
            }

        }
    }
}
