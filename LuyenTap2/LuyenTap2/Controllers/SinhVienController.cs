using LuyenTap2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace LuyenTap2.Controllers
{
    public class SinhVienController : Controller
    {
        private readonly MyDbContext _db;

        public SinhVienController(MyDbContext db) 
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var sv = _db.SinhViens.ToList();
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
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var s = _db.SinhViens.Find(id);
            var sinhvienjson = JsonConvert.SerializeObject(s);
            HttpContext.Session.SetString("SinhVienXoa", sinhvienjson);
            _db.SinhViens.Remove(s);
            _db.SaveChanges();
            return RedirectToAction("Index");  
        }

        public IActionResult Edit(Guid id)
        {
            var s = _db.SinhViens.Find(id);
            var sinhvienjson = JsonConvert.SerializeObject(s);
            HttpContext.Session.SetString("SinhVien", sinhvienjson);
            return View(s); 
        }

        [HttpPost]
        public IActionResult Edit(SinhVien sv)
        {
            _db.SinhViens.Update(sv);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RollBack()
        {
            var s = HttpContext.Session.GetString("SinhVien");
            if(s == null)
            {
                return NotFound();
            }
            else
            {
                var siv = JsonConvert.DeserializeObject<SinhVien>(s);
                _db.SinhViens.Update(siv);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public IActionResult Details(Guid id)
        {
            var s = _db.SinhViens.Find(id);
            return View(s);
        }

        public IActionResult ReviewData()
        {
            var dataD = HttpContext.Session.GetString("SinhVienXoa");
            if (dataD != null)
            {
                var Studeleted = JsonConvert.DeserializeObject<SinhVien>(dataD);
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
            // Lấy đối tượng đã xóa từ Session
            var deletedKhachHangJson = HttpContext.Session.GetString("SinhVienXoa");

            if (!string.IsNullOrEmpty(deletedKhachHangJson))
            {
                // Chuyển đổi JSON thành đối tượng
                var khachHang = JsonConvert.DeserializeObject<SinhVien>(deletedKhachHangJson);

                // Thêm lại đối tượng vào cơ sở dữ liệu
                _db.SinhViens.Add(khachHang);
                _db.SaveChanges();

                // Xóa đối tượng đã xóa khỏi Session sau khi rollback thành công
                HttpContext.Session.Remove("SinhVienXoa");

                return RedirectToAction("Index");
            }

            return NotFound();
        }

    }
}
