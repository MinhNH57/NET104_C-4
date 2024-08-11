using ASM2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ASM2.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly MyDbcontext _db;

        public KhachHangController(MyDbcontext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var khs = _db.khachHangs.ToList();
            return View(khs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(KhachHang kh)
        {
            var new_kh = _db.khachHangs.Add(kh);
            _db.SaveChanges();
            return RedirectToAction("Index" , "KhachHang");
        }

        public IActionResult Update(Guid id)
        {
            KhachHang up = _db.khachHangs.Find(id);
            if(up != null)
            {
                return View(up);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Update(KhachHang kh)
        {

            var existingHocVien = _db.khachHangs.AsNoTracking().FirstOrDefault(hv => hv.Id == kh.Id);
            if (existingHocVien != null)
            {
                var jsonOld = JsonConvert.SerializeObject(existingHocVien);
                HttpContext.Session.SetString("StudentBackup", jsonOld);
            }


            _db.khachHangs.Update(kh);
            _db.SaveChanges();

            return RedirectToAction("Index", "KhachHang");
        }

        public IActionResult Delete(Guid id)
        {
            var delet = _db.khachHangs.Find(id);
            if(delet != null)
            {
                _db.khachHangs.Remove(delet); _db.SaveChanges();
                return RedirectToAction("Index" , "KhachHang");
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult Details(Guid id)
        {
            var d = _db.khachHangs.Find(id);
            return View(d);
        }

        [HttpPost]
        public IActionResult RollBackData()
        {
            if (HttpContext.Session.Keys.Contains("StudentBackup"))
            {
                var jsondata = HttpContext.Session.GetString("StudentBackup");
                var data = JsonConvert.DeserializeObject<KhachHang>(jsondata);

                _db.khachHangs.Update(data);
                _db.SaveChanges();

                HttpContext.Session.Remove("StudentBackup");

                return RedirectToAction("Index", "KhachHang");
            }
            else
            {
                return Content("No backup data found.");
            }

        }
    }
}
