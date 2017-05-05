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
    public class AwardingBodyController : Controller
    {
        private SimsEntities2 db = new SimsEntities2();
        private ModelHelper<Models.AwardingBodyModel, DAL.AwardingBody> mapper = new ModelHelper<Models.AwardingBodyModel, DAL.AwardingBody>();
        
        //
        // GET: /AwardingBody/
        public ActionResult Index(int? pageId = 0)
        {
            var dbModelPage = db.AwardingBodies.OrderByDescending(a => a.Id).Skip((pageId ?? 0) * 100).Take(100).ToList();
            var UiModelPage = dbModelPage.Select(dbmodel => mapper.ToUi(dbmodel));//.OrderByDescending(a=>a.Id);

            return View(UiModelPage);
        }

        //
        // GET: /AwardingBody/Details/5
        public ActionResult Details(int id)
        {
            var p = Get(id);
            var m = mapper.ToUi(p);
            return View(m);
        }

        //
        // GET: /AwardingBody/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AwardingBody/Create
        [HttpPost]
        public ActionResult Create(AwardingBodyModel model)
        {
            try
            {
                // TODO: Add insert logic here

                var dbmodel = mapper.ToDb(model);
                //dbmodel.CreateDate = DateTime.Now;
                db.AwardingBodies.Add(dbmodel);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AwardingBody/Edit/5
        public ActionResult Edit(int id)
        {
            var p = Get(id);
            var m = mapper.ToUi(p);
            return View(m);
        }

        //
        // POST: /AwardingBody/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AwardingBodyModel patch)
        {
            try
            {

                var orignalInDb = Get(id);
               // orignalInDb.EditDate = DateTime.Now;
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
        // GET: /AwardingBody/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var p = Get(id);
                db.AwardingBodies.Remove(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /AwardingBody/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var p = Get(id);
                db.AwardingBodies.Remove(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public AwardingBody Get(int key)
        {
            // person => person.Id == key || (Person person) => {return person.Id == key}
            return db.AwardingBodies.Where(person => person.Id == key).FirstOrDefault();
        }
    }
}
