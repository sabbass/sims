using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResultInformation.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Clerk")]
    public class HomeController :Controller
    {
        //
        // GET: /Admin/Home/
        public ActionResult Index()
        {
            return View();
        }
	}
}