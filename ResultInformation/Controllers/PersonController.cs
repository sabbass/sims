using ResultInformation.DAL;
using ResultInformation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.OData;
using System.Web.Mvc;

namespace ResultInformation.Controllers
{
    public class PersonController : Controller
    {
        private SIMSEntities db = new SIMSEntities();
        private ModelHelper<Models.PersonModel, DAL.Person> mapper = new ModelHelper<Models.PersonModel, DAL.Person>();
        //
        // GET: /Person/
        public ActionResult Index(int? pageId = 0)
        {
            var model = db.People.OrderBy(a => a.Id).Skip((pageId ?? 0) * 100).Take(100).ToList().Select(a => mapper.Reverse(a));

            return View(model);
        }

        //
        // GET: /Person/Details/5
        public ActionResult Details(int id)
        {
            var p = Get(id);
            var m = mapper.Reverse(p);
            return View(m);
        }

        //
        // GET: /Person/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Person/Create
        [HttpPost]
        public ActionResult Create(PersonModel p)
        {
            p.EditDate = DateTime.Now;
            
            var person = mapper.Map(p);
            db.People.Add(person);

            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                //  if (PersonExists(person.Id))
                throw;
                // return Conflict();
            }

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
        // GET: /Person/Edit/5
        public ActionResult Edit(int id)
        {
            var p = Get(id);
            var m = mapper.Reverse(p);
            return View(m);
        }

        //
        // POST: /Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PersonModel patch)
        {

            try
            {

                var p = Get(id);
                p.EditDate = DateTime.Now;
                mapper.Copy(p, patch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Person/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var p = Get(id);
                db.People.Remove(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
           // return View();
        }

        //
        // POST: /Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var p = Get(id);
                db.People.Remove(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public Person Get(int key)
        {
            return db.People.Where(person => person.Id == key).FirstOrDefault();
        }
        private bool PersonExists(int key)
        {
            return db.People.Count(e => e.Id == key) > 0;
        }
    }
}
