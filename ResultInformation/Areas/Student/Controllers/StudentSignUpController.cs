using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ResultInformation.Areas.Student.Models;
using ResultInformation.DAL;
using ResultInformation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResultInformation.Areas.Student.Controllers
{
    [Authorize]
    public class StudentSignUpController : Controller
    {
        private SimsEntities db = new SimsEntities();
        private ModelHelper<ResultInformation.Areas.Student.Models.StudentProfile, DAL.Student> mapper = new ModelHelper<ResultInformation.Areas.Student.Models.StudentProfile, DAL.Student>();

        public StudentSignUpController()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public StudentSignUpController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
            // userManager.U

            ViewBag.Programs = db.Programs.Select(a => new { Id = a.Id, Name = a.Name }).ToList();
            ViewBag.Semesters = db.Semesters.Select(a => new { Id = a.Id, Name = a.Name, Program = a.Program.Name }).ToList().Select(a => new { Id = a.Id, Name = a.Program + " > " + a.Name });
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }
        //
        // GET: /Student/StudentSignUp/
        public ActionResult Index()
        {
            var student = GetStudent();
            if (student == null)
            {
                return RedirectToAction("Create");
            }

            return View(mapper.ToUi(student));
        }

        //
        // GET: /Student/StudentSignUp/Details/5
        public ActionResult Details(int id)
        {
            var student = GetStudent();

            if (student == null)
            {
                return RedirectToAction("Create");
            }

            return View(mapper.ToUi(student));
        }
        public ActionResult Courses(int SemesterId)
        {

            var semister = db.Semesters.FirstOrDefault(a => a.Id == SemesterId);
            var model = semister.Courses.ToList().Select(a => new Models.Course() { Id = a.Id, Name = a.Name, Selected = false });

            // if(semister!=null)


            var student = GetStudent();

            var studentCourses = student.Registrations.Select(a => a.CourseId).ToList();
            studentCourses.ForEach(a =>
            {
                var selected = model.FirstOrDefault(x => x.Id == a);
                if (selected != null)
                {
                    selected.Selected = true;
                }
            });
            return View(model);
        }
        //
        // GET: /Student/StudentSignUp/Create
        public ActionResult Create()
        {
            var student = GetStudent();
            if (student != null)
            {
                return RedirectToAction("Edit");
            }
            ViewBag.Programs = db.Programs.Select(a => new { Id = a.Id, Name = a.Name }).ToList();
            return View();
        }

        //
        // POST: /Student/StudentSignUp/Create
        [HttpPost]
        public ActionResult Create(StudentProfile model)
        {
            try
            {
                // TODO: Add insert logic here
                model.UserId = User.Identity.GetUserId();
                var dbmodel = mapper.ToDb(model);
                dbmodel.UserId = User.Identity.GetUserId();
                //  dbmodel.CreateDate = DateTime.Now;
                db.Students.Add(dbmodel);
                db.SaveChanges();
                var userId = User.Identity.GetUserId(); ;
                if (!User.IsInRole("Student"))
                {
                    UserManager.AddToRole(userId, "Student");
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        //
        // GET: /Student/StudentSignUp/Edit/5
        public ActionResult Edit()
        {

            var student = GetStudent();
            if (student == null)
            {
                return RedirectToAction("Create");
            }

            var model = mapper.ToUi(student);
            return View(model);
        }

        //public ActionResult Courses(int semisterId) {

        //  var courseInSemsiter =  db.Courses.Where(a => a.SemisterId == semisterId);
        //}

        DAL.Student GetStudent()
        {
            var userId = User.Identity.GetUserId(); ;
            var student = db.Students.FirstOrDefault(a => a.UserId == userId);
            return student;
        }
        //
        // POST: /Student/StudentSignUp/Edit/5
        [HttpPost]
        public ActionResult Edit(StudentProfile model)
        {
            try
            {
                model.UserId = User.Identity.GetUserId();
                var orignalInDb = GetStudent();
                var d = mapper.Patch(model, orignalInDb);
                db.Entry(orignalInDb).State = EntityState.Modified;
                db.SaveChanges();
                // TODO: Add update logic here
                model.Courses.ForEach(a =>
                {
                    if (!db.Registrations.Any(x => x.CourseId == a && x.StudentId == orignalInDb.Id))
                    {
                        db.Registrations.Add(new DAL.Registration() { SemesterId = orignalInDb.SemesterId, CourseId = a, StudentId = orignalInDb.Id });
                    }
                });
           //     db.Registrations.RemoveRange()
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Student/StudentSignUp/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Student/StudentSignUp/Delete/5
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
