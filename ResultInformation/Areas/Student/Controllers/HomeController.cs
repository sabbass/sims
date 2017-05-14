using ResultInformation.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResultInformation.Areas.Student.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private SimsEntities db = new SimsEntities();
       // private ModelHelper<ResultInformation.Areas.Student.Models.StudentRegistration, DAL.AcademicSession> mapper = new ModelHelper<ResultInformation.Areas.Admin.Models.AcademicSessionModel, DAL.AcademicSession>();
        //
        // GET: /Student/Home/

        public ActionResult Index()
        {
            var isStudent = User.IsInRole("Student");
            if (!isStudent)
                return RedirectToAction("Create", "StudentSignUp");

            return View();
        }
        //public ActionResult StudentSignUp(StudentModel model)
        //{

        //    try
        //    {
        //        // TODO: Add insert logic here

        //        var dbmodel = mapper.ToDb(model);
        //        //  dbmodel.CreateDate = DateTime.Now;
        //        db.AcademicSessions.Add(dbmodel);
        //        db.SaveChanges();

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

	}
    

}