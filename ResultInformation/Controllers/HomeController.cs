using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResultInformation.DAL;
using ResultInformation.Models;
namespace ResultInformation.Controllers
{
    
    public class HomeController : Controller
    {
        private SimsEntities db = new SimsEntities();
        public ActionResult Index()
        {
            var homeModel = new HomeModel() { };
            homeModel.Articles.AddRange(db.Articles.Where(a => a.IsPublished??false));
            return View(homeModel);
        }

        public ActionResult Article(int Id) {
            var article = db.Articles.Find(Id);
            return View("ShowArticle", article);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}