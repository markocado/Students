using Students.Models;
using Students.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace Students.Controllers
{
    public class StudentsController : Controller
    {

        private ApplicationDbContext dbContext;
        public StudentsController()
        {
            dbContext = new ApplicationDbContext();
        }
        // GET: Student
        public ActionResult List()
        {
            var students = dbContext.Students.Include(i => i.Gender).ToList();
            return View(students);
        }

        public ActionResult Edit(int id)
        {

            var student = dbContext.Students.Single(s => s.Id == id);

            StudentFormViewModel vm = new StudentFormViewModel();
            vm.Genders = dbContext.Genders.ToList();
            vm.Student = student;

            return View("StudentForm", vm);
        }

        public ActionResult Details(int id)
        {
            var student = this.dbContext.Students.Find(id);

            return View(student);
        }

        public ActionResult New()
        {
            StudentFormViewModel vm = new StudentFormViewModel();
            vm.Genders = dbContext.Genders.ToList();
            vm.Student = new Student();
            return View("StudentForm", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Student student)
        {
            if (!ModelState.IsValid)
            {
                StudentFormViewModel vm = new StudentFormViewModel();
                vm.Genders = dbContext.Genders.ToList();
                vm.Student = student;
                return View("StudentForm", vm);
            }

            if (student.Id == 0)
            {
                dbContext.Students.Add(student);
            } 
            else
            {
                var studentInDb = this.dbContext.Students.Single(s => s.Id == student.Id);
                studentInDb.FirstName = student.FirstName;
                studentInDb.LastName = student.LastName;
                studentInDb.GenderId = student.GenderId;
            }

            dbContext.SaveChanges();

            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var student = this.dbContext.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var student = this.dbContext.Students.Find(id);
            if (student == null)
                return HttpNotFound();

            this.dbContext.Students.Remove(student);
            this.dbContext.SaveChanges();

            return RedirectToAction("List");
        }

    }
}