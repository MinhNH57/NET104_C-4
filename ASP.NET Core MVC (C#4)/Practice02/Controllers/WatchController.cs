using Microsoft.AspNetCore.Mvc;
using Practice02.Models;

namespace Practice02.Controllers
{
    public class WatchController : Controller
    {
        private readonly WatchDbContext _db;

        public WatchController(WatchDbContext dbwtach)
        {
            _db = dbwtach;
        }
        public IActionResult Index()
        {
            var watches = _db.Watches.ToList();
            return View(watches);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Watch watch , IFormFile imgFile)
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
            watch.Img = "/Img/" + path;

            _db.Watches.Add(watch);
            _db.SaveChanges();
            return RedirectToAction("Index", "Watch");
        }

        public IActionResult Update(Guid id)
        {
            var update_w = _db.Watches.Find(id);
            if(update_w != null)
            {
                return View(update_w);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Update(Watch watch)
        {
            _db.Watches.Update(watch);
            _db.SaveChanges();
            return RedirectToAction("Index", "Watch");
        }

        //[HttpPost]
        //public IActionResult Delete(Guid id)
        //{
        //    var d = _db.Watches.Find(id);
        //    if(d != null)
        //    {
        //        _db.Watches.Remove(d);
        //        _db.SaveChanges();
        //        return RedirectToAction("Index", "Watch");
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        public IActionResult Delete(Guid id)
        {
            var watch = _db.Watches.Find(id);
            if (watch == null)
            {
                return NotFound();
            }

            return View(watch);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(Guid id)
        {

            var watch = _db.Watches.Find(id);
            if (watch == null)
            {
                return NotFound();
            }

            _db.Watches.Remove(watch);
            _db.SaveChanges();
            return RedirectToAction("Index", "Watch");
        }
    }
}
