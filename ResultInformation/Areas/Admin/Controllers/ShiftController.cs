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
    public class ShiftController : Controller
    {
        private SimsEntities db = new SimsEntities();
        private ModelHelper<ResultInformation.Areas.Admin.Models.ShiftModel, DAL.Shift> mapper = new ModelHelper<ResultInformation.Areas.Admin.Models.ShiftModel, DAL.Shift>();

        //
        // GET: /Admin/Shift/
        public ActionResult Index(int? pageId = 0)
        {
            var dbModelPage = db.Shifts.OrderByDescending(a => a.Id).Skip((pageId ?? 0) * 100).Take(100).ToList();
            var UiModelPage = dbModelPage.Select(dbmodel => mapper.ToUi(dbmodel));//.OrderByDescending(a=>a.Id);

            return View(UiModelPage);
        }

        //
        // GET: /Admin/Shift/Details/5
        public ActionResult Details(int id)
        {
            var p = Get(id);
            var m = mapper.ToUi(p);
            return View(m);
        }

        //
        // GET: /Admin/Shift/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Shift/Create
        [HttpPost]
        public ActionResult Create(ShiftModel model)
        {
            try
            {
                // TODO: Add insert logic here

                var dbmodel = mapper.ToDb(model);
                //  dbmodel.CreateDate = DateTime.Now;
                db.Shifts.Add(dbmodel);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Shift/Edit/5
        public ActionResult Edit(int id)
        {
            var p = Get(id);
            var m = mapper.ToUi(p);
            return View(m);
        }

        //
        // POST: /Admin/Shift/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ShiftModel patch)
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
        // GET: /Admin/Shift/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var p = Get(id);
                db.Shifts.Remove(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Admin/Shift/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var p = Get(id);
                db.Shifts.Remove(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public Shift Get(int key)
        {
            // person => person.Id == key || (Person person) => {return person.Id == key}
            return db.Shifts.Where(person => person.Id == key).FirstOrDefault();
        }
    }
}
