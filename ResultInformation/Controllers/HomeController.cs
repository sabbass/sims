using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResultInformation.DAL;
namespace ResultInformation.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new SIMSEntities();
            //db.People.Add(new Person() {FirstName="Anum",LastName="Abbas" });
            //db.SaveChanges();

          //

            //some test
        //   var saria= db.People.Find(new Person(){FirstName="saria"});
            //saria.Registrations.Add(new Registration(){})
            
            return View();
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