using ResultInformation.Areas.Admin.Models;
using ResultInformation.DAL;
using ResultInformation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResultInformation.Areas.Admin.Controllers
{
    public class SemesterController : Controller
    {private SimsEntities db = new SimsEntities();
        private ModelHelper<ResultInformation.Areas.Admin.Models.SemesterModel, DAL.Semester> mapper = new ModelHelper<ResultInformation.Areas.Admin.Models.SemesterModel, DAL.Semester>();

        //
        //
        // GET: /Admin/Semester/
        public ActionResult Index(int? pageId = 0)
        {
            var dbModelPage = db.Semesters.OrderByDescending(a => a.Id).Skip((pageId ?? 0) * 100).Take(100).ToList();
            var UiModelPage = dbModelPage.Select(dbmodel => mapper.ToUi(dbmodel));//.OrderByDescending(a=>a.Id);

            return View(UiModelPage);
            
        }

        //
        // GET: /Admin/Semester/Details/5
        public ActionResult Details(int id)
        {var p = Get(id);
            var m = mapper.ToUi(p);
            return View(m);
        }

        //
        // GET: /Admin/Semester/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Semester/Create
        [HttpPost]
        public ActionResult Create(SemesterModel model)
        {
           try
            {
                // TODO: Add insert logic here

                var dbmodel = mapper.ToDb(model);
                //  dbmodel.CreateDate = DateTime.Now;
                db.Semesters.Add(dbmodel);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Semester/Edit/5
        public ActionResult Edit(int id)
        {
            
            var p = Get(id);
            var m = mapper.ToUi(p);
            return View(m);
        }

        //
        // POST: /Admin/Semester/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SemesterModel patch)
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
        // GET: /Admin/Semester/Delete/5
        public ActionResult Delete(int id)
        {
          try
            {
                var p = Get(id);
                db.Semesters.Remove(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Admin/Semester/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var p = Get(id);
                db.Semesters.Remove(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public Semester Get(int key)
        {
            // person => person.Id == key || (Person person) => {return person.Id == key}
            return db.Semesters.Where(person => person.Id == key).FirstOrDefault();
        }
    }
}
