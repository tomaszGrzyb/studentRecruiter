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

		public ActionResult MainPage()
		{
			var phase = _dbContext.RecruitmentPhases.Where(p => p.DateFrom <= DateTime.Now && p.DateTo >= DateTime.Now).FirstOrDefault();
			if (phase == null)
			{
				return View("NoRecrutation");
			}
			var all = _dbContext.Recruitments
				.Include(r => r.RequiredSubjects)				
				.Include(r => r.FieldOfStudy)
				.Include(r => r.StudyType).ToList();

			var main = new MainRecruitmentWithTypesViewModel();
			main.PhaseName = phase.Name;
			main.DateFrom = phase.DateFrom.Date.ToString("dd-MM-yyyy");
			main.DateTo = phase.DateTo.Date.ToString("dd-MM-yyyy");
			main.FullTimeStudies = new List<MainRecruitmentViewModel>();
			main.WeekendStudies = new List<MainRecruitmentViewModel>();

			var allViewModels = new List<MainRecruitmentViewModel>();
			foreach (var item in all)
			{
				var vm = new MainRecruitmentViewModel();
				vm.StudyType = item.StudyType.Name;
				vm.FieldOfStudy = item.FieldOfStudy.Name;
				vm.Description = item.FieldOfStudy.Description;
				vm.RequiredSubjects = item.RequiredSubjects.ToList();
				vm.Slots = item.Slots;
				vm.StudyTypeId = item.StudyTypeId;
				allViewModels.Add(vm);
			}
			main.WeekendStudies = allViewModels.Where(r => r.StudyType == StudyTypes.Niestacjonarne.ToString()).ToList();
			main.FullTimeStudies = allViewModels.Where(r => r.StudyType == StudyTypes.Stacjonarne.ToString()).ToList();
			return View(main);
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

		//[Authorize(Roles = "Admin")]
		public ActionResult AdminIndex()
		{
			var all = _dbContext.Recruitments
							.Include(r => r.RequiredSubjects)
							.Include(r => r.StudyType)
							.Include(r => r.StudyLevel)
							.Include(r => r.RecruitmentPhase)
							.Include(r => r.FieldOfStudy)
							.ToList();

			var vmList = new List<AdminRecruitmentViewModel>();
			foreach (var item in all)
			{
				var vm = new AdminRecruitmentViewModel()
				{
					RecruitmentId = item.Id,
					FieldOfStudy = item.FieldOfStudy.Name,
					StudyLevel = item.StudyLevel.Name,
					StudyType = item.StudyType.Name,
					RequiredSubjects = item.RequiredSubjects.ToList(),
					RecruitmentPhase = item.RecruitmentPhase.Name,
					Slots = item.Slots
				};

				vmList.Add(vm);
			}
			return View(vmList);
		}

		//[Authorize(Roles = "Admin")]
		//[HttpGet]
		//public ActionResult Create()
		//{
		//	var all = _dbContext.Recruitments
		//		.Include(r => r.RequiredSubjects)				
		//		.ToList();
		//	var studyTypes = _dbContext.StudyTypes.ToList();
		//	var studyLevels = _dbContext.StudyLevels.ToList();
		//	var phases = _dbContext.RecruitmentPhases.ToList();
		//	var fieldsOfStudies = _dbContext.FieldsOfStudies.ToList();
		//	var allViewModels = new List<AdminCreateRecruitmentViewModel>();

		//	foreach (var item in all)
		//	{
		//		var vm = new AdminCreateRecruitmentViewModel()
		//		{
		//			FieldOfStudyId = item.FieldOfStudyId,
		//			FieldOfStudies = fieldsOfStudies,
		//			RecruitmentId = item.Id,
		//			RecruitmentPhaseId = item.RecruitmentPhaseId,
		//			RecruitmentPhases = phases,
		//			RequiredSubjects = item.RequiredSubjects.ToList(),
		//			Slots = item.Slots,
		//			StudyLevelId = item.StudyLevelId,
		//			StudyLevels = studyLevels,
		//			StudyTypeId = item.StudyTypeId,
		//			StudyTypes = studyTypes
		//		};
		//		allViewModels.Add(vm);
		//	}
		//	return View(allViewModels);
		//}

		[HttpGet]
		public ActionResult Create()
		{
			var studyTypes = _dbContext.StudyTypes.ToList();
			var studyLevels = _dbContext.StudyLevels.ToList();
			var phases = _dbContext.RecruitmentPhases.ToList();
			var fieldsOfStudies = _dbContext.FieldsOfStudies.ToList();		
		
				var vm = new AdminCreateRecruitmentViewModel()
				{
					FieldOfStudies = fieldsOfStudies,			
					RecruitmentPhases = phases,			
					StudyLevels = studyLevels,			
					StudyTypes = studyTypes
				};
			
		
			return View(vm);
		}

		[HttpPost]
		public ActionResult Create(AdminCreateRecruitmentViewModel vm)
		{
			var newRecruitment = new Recruitment()
			{
				RecruitmentPhaseId = vm.RecruitmentPhaseId,
				StudyLevelId = vm.StudyLevelId,
				StudyTypeId = vm.StudyTypeId,
				Slots = vm.Slots,
				FieldOfStudyId = vm.FieldOfStudyId			
			};

			_dbContext.Recruitments.Add(newRecruitment);
			_dbContext.SaveChanges();
			return RedirectToAction("AdminIndex");
		}
		[HttpGet]
		public ActionResult RequiredSubjects(int? Id)
		{
			var subjects = _dbContext.Subjects.ToList();
			var vm = new RequiredSubjectsViewModel()
			{
				RecruitmentId = (int)Id,
				Subjects = subjects
			};
			return View(vm);
		}

		[HttpPost]
		public ActionResult RequiredSubjects(RequiredSubjectsViewModel vm)
		{
			var recruitment = _dbContext.Recruitments.Find(vm.RecruitmentId);
			var subject = _dbContext.Subjects.Find(vm.SubjectId);
			recruitment.RequiredSubjects.Add(subject);
			_dbContext.SaveChanges();
			return RedirectToAction("AdminIndex");
		}

	
		public ActionResult Mine()
		{
			var userId = User.Identity.GetUserId();
			var candidate = _dbContext.Candidates
				.Where(c => c.ApplicationUserId == userId).Single();
			var appliance = _dbContext.Appliances.Where(a => a.CandidateId == candidate.Id)
				.Include( a => a.Recruitment).FirstOrDefault();

			if (appliance != null)
			{

				var fieldOfStudy = _dbContext.FieldsOfStudies.Where(f => f.Id == appliance.Recruitment.FieldOfStudyId).FirstOrDefault();
				var status = _dbContext.RecruitmentStatuses.Where(r => r.Id == appliance.RecruitmentStatusId).FirstOrDefault();
				var phase = _dbContext.RecruitmentPhases.Where(r => r.Id == appliance.Recruitment.RecruitmentPhaseId).FirstOrDefault();
				var allAppliances = _dbContext.Appliances.Where(a => a.RecruitmentId == appliance.RecruitmentId).OrderBy(x => x.Points).ToList();

				var rank = allAppliances.Count + 1;
				for (int i = 0; i < allAppliances.Count; i++)
				{
					if (allAppliances[i].Points < appliance.Points)
					{
						rank = i + 1;
						break;
					}
				}

				var viewModel = new ApplianceViewModel()
				{
					FieldOfStudy = fieldOfStudy.Name,
					Status = status.Name,
					Description = status.Description,
					Points = appliance.Points,
					Rank = rank,
					RecrutationNumber = appliance.RecruitmentNumber.ToString(),
					Slots = appliance.Recruitment.Slots,
					ClosingDate = phase.DateTo.Date.ToString()
				};
				return View(viewModel);
			}
			else
			{
				return RedirectToAction("Index");
			}
			
		}


		[HttpGet]
		public ActionResult Apply(int? id, decimal? points)
		{
			var userId = User.Identity.GetUserId();
			var candidate = _dbContext.Candidates
				.Where(c => c.ApplicationUserId == userId).Single();
			var dbAppliance = _dbContext.Appliances.Where(a => a.CandidateId == candidate.Id).FirstOrDefault();

			if (dbAppliance != null)
			{
				dbAppliance.RecruitmentId = (int)id;
				dbAppliance.Points = (decimal)points;
				dbAppliance.CreationDate = DateTime.Now;
				_dbContext.SaveChanges();
			}
			else
			{
				var appliance = new Appliance();
				appliance.RecruitmentId = (int)id;
				appliance.RecruitmentNumber = Guid.NewGuid();
				appliance.Points = (decimal)points;
				appliance.CandidateId = candidate.Id;
				appliance.CreationDate = DateTime.Now;
				appliance.RecruitmentStatusId = (int)RecruitmentStatuses.WaitingForPayment;
				_dbContext.Appliances.Add(appliance);
				_dbContext.SaveChanges();
			}
		

			return View("Success");
		}

		public ActionResult Details(int? id)
		{
			return View();
		}


		public ActionResult Success()
		{
			return View();
		}


	}
}