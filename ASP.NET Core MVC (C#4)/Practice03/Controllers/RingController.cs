using Microsoft.AspNetCore.Mvc;
using Practice03.Models;

namespace Practice03.Controllers
{
    public class RingController : Controller
    {
        private readonly RingDbContext _db;

        public RingController(RingDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var watch = _db.Rings.ToList();
            return View(watch);
        }

        public IActionResult CreateEmty()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEmty(Ring r , IFormFile imgFile)
        {
            if (imgFile == null || imgFile.Length == 0)
            {
                ModelState.AddModelError("imgFile", "Please upload an image.");
                return BadRequest(ModelState); // Hoặc trả về BadRequest("Please upload an image.");
            }
            //Lay ten file 
            string path = Path.GetFileName(imgFile.FileName);
            string directionPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Img");
            if (!Directory.Exists(directionPath))
            {
                Directory.CreateDirectory(directionPath);
            }
            string filePath = Path.Combine(directionPath, path);
            try
            {
                using (var File = new FileStream(filePath, FileMode.Create))
                {
                    imgFile.CopyTo(File);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("imgFile", $"Failed to upload image: {ex.Message}");
                return View();
            }
            r.Image = "/Img/" + path;

            _db.Rings.Add(r);
            _db.SaveChanges();
            return RedirectToAction("Index", "Ring");
        }
   

        public IActionResult Update(Guid id)
        {
            var up = _db.Rings.Find(id);
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
        public IActionResult Update(Ring r)
        {
            _db.Rings.Update(r);
            _db.SaveChanges();
            return RedirectToAction("Index", "Ring");
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var up = _db.Rings.Find(id);
            if (up != null)
            {
                _db.Rings.Remove(up);
                _db.SaveChanges();
                return RedirectToAction("Index" , "Ring");
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult Details(Guid id)
        {
            var up = _db.Rings.Find(id);
            if (up != null)
            {
                return View(up);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
