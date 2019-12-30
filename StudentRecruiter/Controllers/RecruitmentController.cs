using Microsoft.AspNet.Identity;
using StudentRecruiter.Models;
using StudentRecruiter.Models.Domain;
using StudentRecruiter.Models.Enums;
using StudentRecruiter.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRecruiter.Controllers
{
	public class RecruitmentController : Controller
	{
		private readonly ApplicationDbContext _dbContext;

		public RecruitmentController()
		{
			_dbContext = new ApplicationDbContext();
		}

		public ActionResult Index()
		{
			var now = DateTime.Now;
			var phasesIds = _dbContext.RecruitmentPhases
				.Where(r => r.DateFrom < now && now < r.DateTo).Select(r => r.Id).ToList();

			var currentRecruitments = _dbContext.Recruitments
				.Where(r => phasesIds.Contains(r.RecruitmentPhaseId))
				.Include(r => r.FieldOfStudy)
				.Include(r => r.RequiredSubjects)
				.ToList();

			var userId = User.Identity.GetUserId();
			var candidate = _dbContext.Candidates
				.Where(c => c.ApplicationUserId == userId).Single();
			var exam = _dbContext.Exams.Where(e => e.CandidateDetailsId == candidate.Id).First();
			var examResults = _dbContext.ExamResults
				.Where(e => e.ExamId == exam.Id).ToList();


			var recruitments = new List<RecruitmentViewModel>();

			foreach (var item in currentRecruitments)
			{

				//points
				double maximumPoints = 0;
				foreach (var rs in item.RequiredSubjects )
				{
					var hasExam = examResults.Where(e => e.SubjectId == rs.Id).FirstOrDefault();

					if (hasExam != null)
					{
						double result = 0; 
						if (hasExam.IsAdvanced)						
							result = hasExam.Result * 1.5;						
						else						
							result = hasExam.Result;


						if (result > maximumPoints)
							maximumPoints = result;
					}				
				}

				// rank
				var allAppliances = _dbContext.Appliances.Where(a => a.RecruitmentId == item.Id).OrderBy(x => x.Points).ToList();
				var rank = allAppliances.Count + 1;
				for (int i = 0; i < allAppliances.Count; i++)
				{
					if (allAppliances[i].Points < (decimal)maximumPoints)
					{
						rank = i + 1;
						break;
					}
				}


				var recruitment = new RecruitmentViewModel();
				recruitment.RecruitmentId = item.Id;
				recruitment.StudyTypeId = item.StudyTypeId;
				recruitment.FieldOfStudy = item.FieldOfStudy.Name;
				recruitment.Slots = item.Slots;
				recruitment.Rank = rank;
				recruitment.Points = (decimal)maximumPoints;

				recruitments.Add(recruitment);
			}
			
			var weekendType = _dbContext.StudyTypes.Single(x => x.Name == StudyTypes.Niestacjonarne.ToString());
			var fullTimeType = _dbContext.StudyTypes.Single(x => x.Name == StudyTypes.Stacjonarne.ToString());

			var recruitmentsWithTypes = new RecruitmentWithTypesViewModel();
			recruitmentsWithTypes.FullTimeStudies = recruitments.Where(r => r.StudyTypeId == fullTimeType.Id).ToList();
			recruitmentsWithTypes.WeekendStudies = recruitments.Where(r => r.StudyTypeId == weekendType.Id).ToList();

			return View(recruitmentsWithTypes);
		}

		public ActionResult StartNew()
		{
			return View();
		}

		public ActionResult Apply(int recruitmentId)
		{
			var userId = User.Identity.GetUserId();
			var candidate = _dbContext.Candidates
				.Where(c => c.ApplicationUserId == userId).Single();

			var appliance = new Appliance();
			appliance.RecruitmentId = recruitmentId;
			appliance.RecruitmentNumber = new Guid();			
			appliance.CandidateId = candidate.Id;
			appliance.CreationDate = DateTime.Now;

			_dbContext.Appliances.Add(appliance);
			_dbContext.SaveChanges();

			return View("Success");
		}

		public ActionResult Details()
		{
			return View();
		}


		public ActionResult Success()
		{
			return View();
		}


	}
}