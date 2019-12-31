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
    public class ExamResultsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        
        public ActionResult Index(int examId)
        {
            var examResults = db.ExamResults.Where(e => e.ExamId == examId).Include(e => e.Exam).Include(e => e.Subject);
            return View(examResults.ToList());
        }

		public ActionResult Mine()
		{
			var userId = User.Identity.GetUserId();
			var candidate = db.Candidates
				.Where(c => c.ApplicationUserId == userId).Single();

			var exam = db.Exams.Where(e => e.CandidateDetailsId == candidate.Id).FirstOrDefault();
			if (exam != null )
			{
				return RedirectToAction("Index", "ExamResults", new { examId = exam.Id });
			}
			else
			{
				return RedirectToAction("Create", "ExamResults");
			}
			
		}


		public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamResult examResult = db.ExamResults.Find(id);
            if (examResult == null)
            {
                return HttpNotFound();
            }
            return View(examResult);
        }

		[Authorize]
        public ActionResult Create()
        {
			var results = new ExamResultViewModel();
			var userId = User.Identity.GetUserId();
			var candidate = db.Candidates
				.Where(c => c.ApplicationUserId == userId).Single();

			var exam = db.Exams.Where(e => e.CandidateDetailsId == candidate.Id).FirstOrDefault();
			results.ExamId = exam.Id;
			results.Subjects = db.Subjects.ToList();
		
            return View(results);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExamResultViewModel examResultViewModel)
        {
            if (ModelState.IsValid)
            {
				var userId = User.Identity.GetUserId();
				var candidate = db.Candidates
					.Where(c => c.ApplicationUserId == userId).Single();

				var exam = db.Exams.Where(e => e.CandidateDetailsId == candidate.Id).FirstOrDefault();
				
				var examResult = new ExamResult();
				examResult.ExamId = exam.Id;
				examResult.IsAdvanced = examResultViewModel.IsAdvanced;
				examResult.SubjectId = examResultViewModel.SubjectId;
				examResult.Result = examResultViewModel.Result;
				db.ExamResults.Add(examResult);
                db.SaveChanges();
                return RedirectToAction("Index", "ExamResults", new { examId = exam.Id });
			}          

            return View(examResultViewModel.ExamId);
        }

    
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamResult examResult = db.ExamResults.Find(id);
            if (examResult == null)
            {
                return HttpNotFound();
            }

			var viewModel = new ExamResultViewModel();
			viewModel.ExamId = examResult.ExamId;
			viewModel.ExamResultId = examResult.Id;
			viewModel.Result = examResult.Result;
			viewModel.IsAdvanced = examResult.IsAdvanced;
			viewModel.SubjectId = examResult.SubjectId;
			viewModel.Subjects = db.Subjects.ToList();
			return View(viewModel);
		}

        // POST: ExamResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExamResultViewModel examResult)
        {
			var dbExamResult = db.ExamResults.Where(e => e.Id == examResult.ExamResultId).Single();
			if (ModelState.IsValid)
            {
				dbExamResult.IsAdvanced = examResult.IsAdvanced;
				dbExamResult.Result = examResult.Result;
				dbExamResult.SubjectId = examResult.SubjectId;

				db.SaveChanges();                
            }
			return RedirectToAction("Index", "ExamResults", new { examId = dbExamResult.ExamId });
		}

        // GET: ExamResults/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamResult examResult = db.ExamResults.Where(e => e.Id == id).Include(e => e.Subject).Single();
            if (examResult == null)
            {
                return HttpNotFound();
            }
            return View(examResult);
        }

        // POST: ExamResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExamResult examResult = db.ExamResults.Find(id);
            db.ExamResults.Remove(examResult);
            db.SaveChanges();
			return RedirectToAction("Index", "ExamResults", new { examId = examResult.ExamId });
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
