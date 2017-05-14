using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ResultInformation.Areas.Student.Models;
using ResultInformation.DAL;
using ResultInformation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace ResultInformation.Areas.Student.Controllers
{
    [Authorize(Roles="Student")]
    public class CoursesController : Controller
    {
        private SimsEntities db = new SimsEntities();
        DAL.Student GetStudent()
        {
            var userId = User.Identity.GetUserId(); ;
            var student = db.Students.FirstOrDefault(a => a.UserId == userId);
            return student;
        }
        //
        // GET: /Student/Courses/
        public ActionResult Index()
        {
            var student = GetStudent();
           // var semisters = student.Program.Semesters.ToList().Select(a=>new(;
          //  ViewBag.Semisters = semisters;
            
            return View();
        }

        //
        // GET: /Student/Courses/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Student/Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Student/Courses/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Student/Courses/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Student/Courses/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Student/Courses/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Student/Courses/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
