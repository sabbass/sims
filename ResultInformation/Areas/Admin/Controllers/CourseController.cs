using ResultInformation.DAL;
using ResultInformation.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResultInformation.Models;

namespace ResultInformation.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Clerk")]
    public class CourseController : Controller
    {
        private SimsEntities db = new SimsEntities();
        private ModelHelper<ResultInformation.Areas.Admin.Models.CourseModel, DAL.Course> mapper = new ModelHelper<ResultInformation.Areas.Admin.Models.CourseModel, DAL.Course>();

        //
        // GET: /Course/
        public ActionResult Index(int? pageId = 0)
        {
            var dbModelPage = db.Courses.OrderByDescending(a => a.Id).Skip((pageId ?? 0) * 100).Take(100).ToList();
            var UiModelPage = dbModelPage.Select(dbmodel => mapper.ToUi(dbmodel));//.OrderByDescending(a=>a.Id);

            return View(UiModelPage);
        }

        //
        // GET: /Course/Details/5
        public ActionResult Details(int id)
        {
            var p = Get(id);
            var m = mapper.ToUi(p);
            return View(m);
        }

        //
        // GET: /Course/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Course/Create
        [HttpPost]
        public ActionResult Create(CourseModel model)
        {
            try
            {
                // TODO: Add insert logic here

                var dbmodel = mapper.ToDb(model);
                //dbmodel.CreateDate = DateTime.Now;
                db.Courses.Add(dbmodel);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Course/Edit/5
        public ActionResult Edit(int id)
        {
            var p = Get(id);
            var m = mapper.ToUi(p);
            return View(m);
        }

        //
        // POST: /Course/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CourseModel patch)
        {
            try
            {

                var orignalInDb = Get(id);
                //  orignalInDb.EditDate = DateTime.Now;
                var d = mapper.Patch(patch, orignalInDb);
                db.Entry(orignalInDb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Course/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var p = Get(id);
                db.Courses.Remove(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Course/Delete/5
        [HttpPost]
        //public ActionResult Delete(int id, CourseModel c)
        //{
        //    try
        //    {
        //        var p = Get(id);
        //        db.Courses.Remove(p);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        public Course Get(int key)
        {
            // person => person.Id == key || (Person person) => {return person.Id == key}
            return db.Courses.Where(person => person.Id == key).FirstOrDefault();
        }
    }
}
