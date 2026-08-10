using Microsoft.AspNetCore.Mvc;
using MvcAppWithDBForJenkins.Models;
namespace MvcAppWithDBForJenkins.Controllers
{
    public class ProductController : Controller
    {
        CoreapidbContext db;
        public ProductController(CoreapidbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            ViewData["products"] = db.TblProducts.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Index(TblProduct pr)
        {
            db.TblProducts.Add(pr);
            db.SaveChanges();
            ModelState.Clear();
            ViewBag.msg = "Product Added Successfully";
            ViewData["products"] = db.TblProducts.ToList();

            return View();
        }
    }
}
