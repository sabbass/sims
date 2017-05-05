using ResultInformation.DAL;
using ResultInformation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResultInformation.Controllers
{
    public class InstituteController : Controller
    {
        private SimsEntities2 db = new SimsEntities2();
        private ModelHelper<Models.InstituteModel, DAL.Institute> mapper = new ModelHelper<Models.InstituteModel, DAL.Institute>();

        //
        //
        // GET: /Institute/
        public ActionResult Index(int? pageId = 0)
        {
            var dbModelPage = db.Institutes.OrderByDescending(a => a.Id).Skip((pageId ?? 0) * 100).Take(100).ToList();
            var UiModelPage = dbModelPage.Select(dbmodel => mapper.ToUi(dbmodel));//.OrderByDescending(a=>a.Id);

            return View(UiModelPage);
        }

        //
        // GET: /Institute/Details/5
        public ActionResult Details(int id)
        {
            var p = Get(id);
            var m = mapper.ToUi(p);
            return View(m);
        }

        //
        // GET: /Institute/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Institute/Create
        [HttpPost]
        public ActionResult Create(InstituteModel model)
        {
            try
            {
                // TODO: Add insert logic here

                var dbmodel = mapper.ToDb(model);
              //  dbmodel.CreateDate = DateTime.Now;
                db.Institutes.Add(dbmodel);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Institute/Edit/5
        public ActionResult Edit(int id)
        {
            var p = Get(id);
            var m = mapper.ToUi(p);
            return View(m);
        }

        //
        // POST: /Institute/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, InstituteModel patch)
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
        // GET: /Institute/Delete/5
        public ActionResult Delete(int id)
        {
           try
            {
                var p = Get(id);
                db.Institutes.Remove(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Institute/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var p = Get(id);
                db.Institutes.Remove(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public Institute Get(int key)
        {
            // person => person.Id == key || (Person person) => {return person.Id == key}
            return db.Institutes.Where(person => person.Id == key).FirstOrDefault();
        }
    }
}
