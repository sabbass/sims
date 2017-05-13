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
    [Authorize(Roles = "Admin,Clerk")]
    public class AcademicLevelController : Controller
    {
        private SimsEntities db = new SimsEntities();
        private ModelHelper<ResultInformation.Areas.Admin.Models.AcademicLevelModel, DAL.AcademicLevel> mapper = new ModelHelper<ResultInformation.Areas.Admin.Models.AcademicLevelModel, DAL.AcademicLevel>();
        //
        // GET: /Admin/Level/
        public ActionResult Index(int? pageId = 0)
        {
            var dbModelPage = db.AcademicLevels.OrderByDescending(a => a.Id).Skip((pageId ?? 0) * 100).Take(100).ToList();
            var UiModelPage = dbModelPage.Select(dbmodel => mapper.ToUi(dbmodel));//.OrderByDescending(a=>a.Id);

            return View(UiModelPage);
        }

        //
        // GET: /Admin/Level/Details/5
        public ActionResult Details(int id)
        {
            var p = Get(id);
            var m = mapper.ToUi(p);
            return View(m);
        }

        //
        // GET: /Admin/Level/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Level/Create
        [HttpPost]
        public ActionResult Create(AcademicLevelModel model)
        {
            try
            {
                // TODO: Add insert logic here

                var dbmodel = mapper.ToDb(model);
                //  dbmodel.CreateDate = DateTime.Now;
                db.AcademicLevels.Add(dbmodel);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Level/Edit/5
        public ActionResult Edit(int id)
        {
            var p = Get(id);
            var m = mapper.ToUi(p);
            return View(m);
        }

        //
        // POST: /Admin/Level/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AcademicLevelModel patch)
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
        // GET: /Admin/Level/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var p = Get(id);
                db.AcademicLevels.Remove(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Admin/Level/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var p = Get(id);
                db.AcademicLevels.Remove(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public AcademicLevel Get(int key)
        {
            // person => person.Id == key || (Person person) => {return person.Id == key}
            return db.AcademicLevels.Where(person => person.Id == key).FirstOrDefault();
        }
    }
}
