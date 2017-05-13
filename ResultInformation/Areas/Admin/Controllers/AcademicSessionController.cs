using ResultInformation.Areas.Admin.Models;
using ResultInformation.Models;
using ResultInformation.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResultInformation.Areas.Account.Controllers
{
    [Authorize(Roles = "Admin,Clerk")]
    public class AcademicSessionController : Controller
    {
        private SimsEntities db = new SimsEntities();
        private ModelHelper<ResultInformation.Areas.Admin.Models.AcademicSessionModel, DAL.AcademicSession> mapper = new ModelHelper<ResultInformation.Areas.Admin.Models.AcademicSessionModel, DAL.AcademicSession>();

        //
        // GET: /Admin/AcademicSession/
        public ActionResult Index(int? pageId = 0)
        {
            var dbModelPage = db.AcademicSessions.OrderByDescending(a => a.Id).Skip((pageId ?? 0) * 100).Take(100).ToList();
            var UiModelPage = dbModelPage.Select(dbmodel => mapper.ToUi(dbmodel));//.OrderByDescending(a=>a.Id);

            return View(UiModelPage);
        }

        //
        // GET: /Admin/AcademicSession/Details/5
        public ActionResult Details(int id)
        {
            var p = Get(id);
            var m = mapper.ToUi(p);
            return View(m);
        }

        //
        // GET: /Admin/AcademicSession/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/AcademicSession/Create
        [HttpPost]
        public ActionResult Create(AcademicSessionModel model)
        {

            try
            {
                // TODO: Add insert logic here

                var dbmodel = mapper.ToDb(model);
                //  dbmodel.CreateDate = DateTime.Now;
                db.AcademicSessions.Add(dbmodel);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/AcademicSession/Edit/5
        public ActionResult Edit(int id)
        {
            var p = Get(id);
            var m = mapper.ToUi(p);
            return View(m);
        }

        //
        // POST: /Admin/AcademicSession/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AcademicSessionModel patch)
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
        // GET: /Admin/AcademicSession/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var p = Get(id);
                db.AcademicSessions.Remove(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Admin/AcademicSession/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var p = Get(id);
                db.AcademicSessions.Remove(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public AcademicSession Get(int key)
        {
            // person => person.Id == key || (Person person) => {return person.Id == key}
            return db.AcademicSessions.Where(person => person.Id == key).FirstOrDefault();
        }
    }
}
