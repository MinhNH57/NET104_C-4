using Microsoft.AspNetCore.Mvc;
using Data_Minh;
using Data_Minh.Models;
using Data_Minh.Repository;
using Microsoft.EntityFrameworkCore;

namespace DemoGH.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly IAllRepository<SanPham> _repo;

        public SanPhamController(IAllRepository<SanPham> repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var listsp = _repo.GetAll();
            return View(listsp);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SanPham sp)
        {
            _repo.CreateObj(sp);
            return RedirectToAction("Index" , "SanPham");
        }
    }
}
