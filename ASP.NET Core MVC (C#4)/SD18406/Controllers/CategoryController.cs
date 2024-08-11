using Microsoft.AspNetCore.Mvc;
using SD18406.Models;
using System.Reflection.Metadata;
using System.Text.Encodings.Web;
using static System.Collections.Specialized.BitVector32;

namespace SD18406.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryDbContext _dbContext;
        public CategoryController(CategoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
         
        [HttpGet]
        public IActionResult Index()
        {
            var categoryList = _dbContext.Categories.ToList();
            return View(categoryList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Catregory cat , IFormFile imgFile)
        {

            if (imgFile == null || imgFile.Length == 0)
            {
                ModelState.AddModelError("imgFile", "Please upload an image.");
                return View(cat); // Hoặc trả về BadRequest("Please upload an image.");
            }

            string fileName = Path.GetFileName(imgFile.FileName);
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Img");

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = Path.Combine(directoryPath, fileName);

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imgFile.CopyTo(stream);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("imgFile", $"Failed to upload image: {ex.Message}");
                return View(cat); // Hoặc trả về StatusCode(500, ex.Message);
            }

            cat.ImgURL = "/Img/" + fileName; // Đường dẫn tương đối của ảnh

            _dbContext.Categories.Add(cat);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Category");

        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var delete_Category = _dbContext.Categories.Find(id);
            if (delete_Category != null)
            {
                _dbContext.Categories.Remove(delete_Category);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult Edit(int? id)
        {
            if(id == null && id == 0)
            {
                return NotFound();
            }
            var categoryEdit = _dbContext.Categories.Find(id);
            if(categoryEdit == null)
            {
                return NotFound();
            }
            return View(categoryEdit);
        }

        [HttpPost]
        public IActionResult Edit(Catregory catregory)
        {
            _dbContext.Categories.Update(catregory);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
