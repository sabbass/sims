using ResultInformation.DAL;
using ResultInformation.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResultInformation.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Clerk")]
    public class StudentController : Controller
    {
        private SimsEntities2 db = new SimsEntities2();
        private ModelHelper<ResultInformation.Areas.Admin.Models.StudentModel, DAL.Student> mapper = new ModelHelper<ResultInformation.Areas.Admin.Models.StudentModel, DAL.Student>();
        //
        // GET: /Student/
        public ActionResult Index(int? pageId = 0)
        {
            var dbModelPage = db.Students.OrderByDescending(a => a.Id).Skip((pageId ?? 0) * 100).Take(100).ToList();
            var UiModelPage = dbModelPage.Select(dbmodel => mapper.ToUi(dbmodel));//.OrderByDescending(a=>a.Id);

            return View(UiModelPage);
        }

        //
        // GET: /Student/Details/5
        public ActionResult Details(int id)
        {
            var p = Get(id);
            var m = mapper.ToUi(p);
            return View(m);
        }

        //
        // GET: /Student/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Student/Create
        [HttpPost]
        public ActionResult Create(StudentModel model)
        {
            try
            {
                // TODO: Add insert logic here

                var dbmodel = mapper.ToDb(model);
                //dbmodel.CreateDate = DateTime.Now;
                db.Students.Add(dbmodel);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Student/Edit/5
        public ActionResult Edit(int id)
        {
            var p = Get(id);
            var m = mapper.ToUi(p);
            return View(m);
        }

        //
        // POST: /Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StudentModel patch)
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
        // GET: /Student/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var p = Get(id);
                db.Students.Remove(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var p = Get(id);
                db.Students.Remove(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public Student Get(int key)
        {
            // person => person.Id == key || (Person person) => {return person.Id == key}
            return db.Students.Where(person => person.Id == key).FirstOrDefault();
        }
    }
}