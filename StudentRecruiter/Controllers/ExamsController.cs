using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using StudentRecruiter.Models;
using StudentRecruiter.Models.Domain;
using StudentRecruiter.Models.ViewModels;

namespace StudentRecruiter.Controllers
{
    public class ExamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Exams
        public ActionResult Index()
        {
            var exams = db.Exams.Include(e => e.School);
            return View(exams.ToList());
        }

        // GET: Exams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // GET: Exams/Create
        public ActionResult Create()
        {
         
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExamViewModel exam)
        {
            if (ModelState.IsValid)
            {
				var address = new Address()
				{
					City = exam.City,
					Country = exam.Country,
					Street = exam.Street,
					ZipCode = exam.ZipCode,
					HouseNumber = exam.HouseNumber
				};

				var addressId = db.Addresses.Add(address).Id;
				var school = new School()
				{
					AddressId = addressId,
					Name = exam.SchoolName,
				};

				var schoolId = db.Schools.Add(school).Id;
				var userId = User.Identity.GetUserId();
				var candidate = db.Candidates
					.Where(c => c.ApplicationUserId == userId).Single();
				var newExam = new Exam()
				{
					CandidateDetailsId = candidate.Id,
					ExamDate = exam.ExamDate,
					Results = new List<ExamResult>(),
					SchoolId = schoolId
				};
				

				var examDb = db.Exams.Add(newExam);
		

				
				db.SaveChanges();

                return RedirectToAction("Index", "ExamResults", new{ examId = examDb.Id });
            }

            return View(exam);
        }

        // GET: Exams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            ViewBag.SchoolId = new SelectList(db.Schools, "Id", "Name", exam.SchoolId);
            return View(exam);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SchoolId,ExamDate")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SchoolId = new SelectList(db.Schools, "Id", "Name", exam.SchoolId);
            return View(exam);
        }

        // GET: Exams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exam exam = db.Exams.Find(id);
            db.Exams.Remove(exam);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
