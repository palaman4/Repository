using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Provider;
namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private RepoProvider _repoProvider;
        public HomeController():base() {
            //Todo configure dependency injection 
            _repoProvider = new RepoProvider();
        }
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Cars()
        {
            var cars = _repoProvider.GetCategoryWithProducts("Cars");
         
            //Todo bind with a viewModel for compile time validation.
            ViewBag.cat = cars.FirstOrDefault();
            ViewBag.Message = "Your chosen car details.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}