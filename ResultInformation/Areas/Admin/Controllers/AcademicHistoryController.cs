using ResultInformation.Areas.Admin.Models;
using ResultInformation.DAL;
using ResultInformation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResultInformation.Areas.Admin.Controllers
{
    public class AcademicHistoryController : Controller
    {
        private SimsEntities db = new SimsEntities();
        private ModelHelper<ResultInformation.Areas.Admin.Models.AcademicHistoryModel, DAL.AcademicHistory> mapper = new ModelHelper<ResultInformation.Areas.Admin.Models.AcademicHistoryModel, DAL.AcademicHistory>();

        //
        // GET: /Admin/AcademicHistory/
        public ActionResult Index()
        {
            //var dbModelPage = db.AcademicHistories.OrderByDescending(a => a.Id).Skip((pageId ?? 0) * 100).Take(100).ToList();
            //var UiModelPage = dbModelPage.Select(dbmodel => mapper.ToUi(dbmodel));//.OrderByDescending(a=>a.Id);

            //return View(UiModelPage);
            List < AcademicHistory > hislist= db.AcademicHistories.ToList();
            AcademicHistoryModel model = new AcademicHistoryModel();
            List<AcademicHistoryModel> list = hislist.Select(x => new AcademicHistoryModel
            { StudentId =x.StudentId,
                Percentage = x.Percentage,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
               
               // Student = x.Student.FatherFirstName,
                Combination=x.Combination.Name,
                AwardingBody = x.AwardingBody.Name,
                Institute = x.Institute.Name,
                AcademicLevel = x.AcademicLevel.Name



            }).ToList();
            return View(list);
        }

        //
        // GET: /Admin/AcademicHistory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/AcademicHistory/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/AcademicHistory/Create
        [HttpPost]
        public ActionResult Create(AcademicHistoryModel model)
        {
            try
            {
                // TODO: Add insert logic here

                var dbmodel = mapper.ToDb(model);
                //  dbmodel.CreateDate = DateTime.Now;
                db.AcademicHistories.Add(dbmodel);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/AcademicHistory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/AcademicHistory/Edit/5
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
        // GET: /Admin/AcademicHistory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/AcademicHistory/Delete/5
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
