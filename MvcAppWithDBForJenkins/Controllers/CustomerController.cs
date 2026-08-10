using Microsoft.AspNetCore.Mvc;
using MvcAppWithDBForJenkins.Models;

namespace MvcAppWithDBForJenkins.Controllers
{
    public class CustomerController : Controller
    {
        CoreapidbContext db;
        public CustomerController(CoreapidbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            ViewData["customers"] = db.TblCustomers.ToList();
            return View();
        }
    }
}
