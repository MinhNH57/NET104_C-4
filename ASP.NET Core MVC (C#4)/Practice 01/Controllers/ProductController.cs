using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practice_01.Models;



namespace Practice_01.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDbContext _db;

        public ProductController (ProductDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categoryList = _db.Products.ToList();
            return View(categoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product prod , IFormFile imgFile)
        {
            if (imgFile == null || imgFile.Length == 0)
            {
                ModelState.AddModelError("imgFile", "Please upload an image.");
                return BadRequest(ModelState); // Hoặc trả về BadRequest("Please upload an image.");
            }
            //Lay ten file 
            string path = Path.GetFileName(imgFile.FileName);
            string directionPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" , "Img");
            if(!Directory.Exists(directionPath))
            {
                Directory.CreateDirectory(directionPath);
            }
            string filePath = Path.Combine(directionPath, path);
            try
            {
                using (var File = new FileStream(filePath , FileMode.Create))
                {
                    imgFile.CopyTo(File);
                }
            }catch(Exception ex)
            {
                ModelState.AddModelError("imgFile", $"Failed to upload image: {ex.Message}");
                return View();
            }
            prod.ImgUrl = "/Img/" + path;

            _db.Products.Add(prod);
            _db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var deletePro =_db.Products.Find(id);
            if(deletePro != null)
            {
                _db.Products.Remove(deletePro);
                _db.SaveChanges();
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult Edit(Guid? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var product_Edit = _db.Products.Find(id);
            if(product_Edit == null)
            {
                return NotFound();
            }
            return View(product_Edit);
        }


        [HttpPost]
        public IActionResult Edit(Product Pr , IFormFile imgFile)
        {

            if ( imgFile != null && imgFile.Length > 0)
            {
                string path = Path.GetFileName(imgFile.FileName);
                string direcPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot" , "Img");
                if(!Directory.Exists(direcPath))
                {
                    Directory.CreateDirectory(direcPath);
                }

                string File_Path = Path.Combine(direcPath, path);

                using (var file = new FileStream(File_Path , FileMode.Create))
                {
                    imgFile.CopyTo(file);
                }

                Pr.ImgUrl = "/Img/" +path;
            }
            else
            {
                var existingProduct = _db.Products.AsNoTracking().FirstOrDefault(p => p.ID == Pr.ID);
                if (existingProduct != null)
                {
                    Pr.ImgUrl = existingProduct.ImgUrl;
                }
            }
            _db.Products.Update(Pr);
            _db.SaveChanges();
            return RedirectToAction("Index" , "Product");
        }
    }
}
