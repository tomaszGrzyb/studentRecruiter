using StudentRecruiter.Models.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using StudentRecruiter.Models.ViewModels;
using StudentRecruiter.Models;

namespace StudentRecruiter.Controllers
{

	public class CandidateDetailsController : Controller
	{
		private readonly ApplicationDbContext _dbContext;

		public CandidateDetailsController()
		{
			_dbContext = new ApplicationDbContext();
		}

		[HttpGet]
		public ActionResult Details()
		{

			var userId = User.Identity.GetUserId();
			var candidate = _dbContext.Candidates
				.Where(c => c.ApplicationUserId == userId)
				.Include(c => c.ApplicationUser)
				.Include(c => c.Address)
				.Include(c => c.Document)				
				.FirstOrDefault();

			if (candidate == null)
			{
				return RedirectToAction("Create");
			}

			var candidateDetails = new CandidateDetailsViewModel();

			candidateDetails.FirstName = candidate.ApplicationUser.FirstName;
			candidateDetails.LastName = candidate.ApplicationUser.LastName;
			candidateDetails.SecondName = candidate.SecondName;
			candidateDetails.Pesel = candidate.Pesel;
			candidateDetails.PhoneNumber = candidate.PhoneNumber;
			candidateDetails.PlaceOfBirth = candidate.PlaceOfBirth;
			candidateDetails.DateOfBirth = candidate.DateOfBirth.Date.ToString();

			if (candidate.Address != null)
			{
				candidateDetails.ApartmentNumber = candidate.Address.ApartmentNumber;
				candidateDetails.HouseNumber = candidate.Address.HouseNumber;
				candidateDetails.City = candidate.Address.City;
				candidateDetails.Country = candidate.Address.Country;
				candidateDetails.ZipCode = candidate.Address.ZipCode;
			}


			if (candidate.Document != null)
			{
				var documentType = _dbContext.DocumentTypes
					.Where(d => d.Id == candidate.Document.DocumentTypeId)
					.FirstOrDefault();

				candidateDetails.DocumentType = documentType.Name;
				candidateDetails.SerialNumber = candidate.Document.SerialNumber;
				candidateDetails.ExpirationDate = candidate.Document.ExpirationDate.Date.ToString();
			}
			var exam = _dbContext.Exams.Where(e => e.CandidateDetailsId == candidate.Id)
				.Include( e => e.School)				
				.FirstOrDefault();

			if (exam != null && exam.School != null )
			{
				var schoolAddress = _dbContext.Addresses.Where(a => a.Id == exam.School.AddressId).FirstOrDefault();
				if (schoolAddress != null)
				{
					candidateDetails.SchoolCity = schoolAddress.City;
					candidateDetails.SchoolCountry = schoolAddress.Country;
					candidateDetails.SchoolNumber = schoolAddress.HouseNumber;
					candidateDetails.SchoolStreet = schoolAddress.Street;
					candidateDetails.SchoolZipCode = schoolAddress.ZipCode;
				}

				candidateDetails.SchoolName = exam.School.Name;			

				var results = _dbContext.ExamResults.Where(e => e.ExamId == exam.Id)
					.Include(e => e.Subject).ToList();

				foreach (var r in results)
				{
					candidateDetails.ExamResults.Add(
						new ExamResultDetailsViewModel()
						{
							IsAdvanced = r.IsAdvanced,
							Result = r.Result,
							Subject = r.Subject.Name
						});
				}
			}

			return View(candidateDetails);
		}


		[HttpGet]
		public ActionResult Edit()
		{

			var userId = User.Identity.GetUserId();
			var candidate = _dbContext.Candidates
				.Where(c => c.ApplicationUserId == userId)
				.Include(c => c.ApplicationUser)
				.Include(c => c.Address)
				.Include(c => c.Document)
				.FirstOrDefault();

			if (candidate == null)
			{
				return RedirectToAction("Create");
			}

			var candidateDetails = new CandidateDetailsEditViewModel();

			candidateDetails.FirstName = candidate.ApplicationUser.FirstName;
			candidateDetails.LastName = candidate.ApplicationUser.LastName;
			candidateDetails.SecondName = candidate.SecondName;
			candidateDetails.Pesel = candidate.Pesel;
			candidateDetails.PhoneNumber = candidate.PhoneNumber;
			candidateDetails.PlaceOfBirth = candidate.PlaceOfBirth;
			candidateDetails.DateOfBirth = candidate.DateOfBirth.Date;

			if (candidate.Address != null)
			{
				candidateDetails.ApartmentNumber = candidate.Address.ApartmentNumber;
				candidateDetails.HouseNumber = candidate.Address.HouseNumber;
				candidateDetails.City = candidate.Address.City;
				candidateDetails.Country = candidate.Address.Country;
				candidateDetails.ZipCode = candidate.Address.ZipCode;
			}

			candidateDetails.DocumentTypes = _dbContext.DocumentTypes.ToList();
			if (candidate.Document != null)
			{
				var documentType = _dbContext.DocumentTypes
					.Where(d => d.Id == candidate.Document.DocumentTypeId)
					.FirstOrDefault();
				
				candidateDetails.DocumentTypeId = (short)documentType.Id;
				candidateDetails.SerialNumber = candidate.Document.SerialNumber;
				candidateDetails.ExpirationDate = candidate.Document.ExpirationDate.Date;
			}
			var exam = _dbContext.Exams.Where(e => e.CandidateDetailsId == candidate.Id)
				.Include(e => e.School)
				.FirstOrDefault();
			
			if (exam != null && exam.School != null)
			{
				candidateDetails.ExamId = exam.Id;

				var schoolAddress = _dbContext.Addresses.Where(a => a.Id == exam.School.AddressId).FirstOrDefault();
				if (schoolAddress != null)
				{
					candidateDetails.SchoolCity = schoolAddress.City;
					candidateDetails.SchoolCountry = schoolAddress.Country;
					candidateDetails.SchoolNumber = schoolAddress.HouseNumber;
					candidateDetails.SchoolStreet = schoolAddress.Street;
					candidateDetails.SchoolZipCode = schoolAddress.ZipCode;
				}

				candidateDetails.SchoolName = exam.School.Name;
			
			}
			

			return View(candidateDetails);
		}

		[HttpPost]
		public ActionResult Edit(CandidateDetailsEditViewModel candidateDetails)
		{

			var userId = User.Identity.GetUserId();
			var candidate = _dbContext.Candidates
				.Where(c => c.ApplicationUserId == userId)
				.Include(c => c.ApplicationUser)
				.Include(c => c.Address)
				.Include(c => c.Document)
				.FirstOrDefault();

			if (candidate == null)
			{
				return RedirectToAction("Create");
			}			

			candidate.SecondName = candidateDetails.SecondName;
			candidate.Pesel = candidateDetails.Pesel;
			candidate.PhoneNumber = candidateDetails.PhoneNumber;
			candidate.PlaceOfBirth = candidateDetails.PlaceOfBirth;
			candidate.DateOfBirth = candidateDetails.DateOfBirth;

			if (candidate.Address != null)
			{
				candidate.Address.ApartmentNumber = candidateDetails.ApartmentNumber;
				candidate.Address.HouseNumber = candidateDetails.HouseNumber;
				candidate.Address.City = candidateDetails.City;
				candidate.Address.Country = candidateDetails.Country;
				candidate.Address.ZipCode = candidateDetails.ZipCode;
			}
			else
			{
				var address = new Address();
				address.ApartmentNumber = candidateDetails.ApartmentNumber;
				address.HouseNumber = candidateDetails.HouseNumber;
				address.City = candidateDetails.City;
				address.Country = candidateDetails.Country;
				address.ZipCode = candidateDetails.ZipCode;
				_dbContext.Addresses.Add(address);

				candidate.AddressId = address.Id;
			}

			candidateDetails.DocumentTypes = _dbContext.DocumentTypes.ToList();
			if (candidate.Document != null)
			{

				candidate.DocumentId = candidateDetails.DocumentTypeId;
				candidate.Document.SerialNumber = candidateDetails.SerialNumber;
				candidate.Document.ExpirationDate = candidateDetails.ExpirationDate;
			}
			var exam = _dbContext.Exams.Where(e => e.CandidateDetailsId == candidate.Id)
				.Include(e => e.School)
				.FirstOrDefault();

			if (exam != null && exam.School != null)
			{
				var schoolAddress = _dbContext.Addresses.Where(a => a.Id == exam.School.AddressId).FirstOrDefault();
				if (schoolAddress != null)
				{
					schoolAddress.City = candidateDetails.SchoolCity;
					schoolAddress.Country = candidateDetails.SchoolCountry;
					schoolAddress.HouseNumber = candidateDetails.SchoolNumber;
					schoolAddress.Street = candidateDetails.SchoolStreet;
					schoolAddress.ZipCode = candidateDetails.SchoolZipCode;

				}

				exam.School.Name = candidateDetails.SchoolName;
			}
		
			_dbContext.SaveChanges();

			return RedirectToAction("Details");
		}

		[HttpGet]
		public ActionResult Create()
		{
			var candidateViewModel = new CandidateViewModel();
			var userId = User.Identity.GetUserId();

			var user = _dbContext.Users.Where(x => x.Id == userId).Single();

			candidateViewModel.FirstName = user.FirstName;
			candidateViewModel.LastName = user.LastName;
			candidateViewModel.DocumentTypes = _dbContext.DocumentTypes.ToList();

			return View(candidateViewModel);
		}

		[HttpPost]
		public ActionResult Create(CandidateViewModel candidate)
		{
			if (!ModelState.IsValid)
			{

				var candidateViewModel = new CandidateViewModel();
				var userIdd = User.Identity.GetUserId();

				var user = _dbContext.Users.Where(x => x.Id == userIdd).Single();

				candidateViewModel.FirstName = user.FirstName;
				candidateViewModel.LastName = user.LastName;
				candidateViewModel.DocumentTypes = _dbContext.DocumentTypes.ToList();

				return View(candidateViewModel);
			}

			var userId = User.Identity.GetUserId();
			var address = new Address()
			{
				City = candidate.City,
				Street = candidate.Street,
				HouseNumber = candidate.HouseNumber,
				Country = candidate.Country,
				ZipCode = candidate.ZipCode,
				ApartmentNumber = candidate.ApartmentNumber
			};

			var addressId = _dbContext.Addresses.Add(address).Id;
			var document = new Document()
			{
				SerialNumber = candidate.SerialNumber,
				DocumentTypeId = candidate.DocumentTypeId,
				ExpirationDate = candidate.ExpirationDate
			};
			var documentId = _dbContext.Documents.Add(document).Id;

			var newCandidate = new CandidateDetails()
			{
				SecondName = candidate.SecondName,
				DateOfBirth = candidate.DateOfBirth,
				Pesel = candidate.Pesel,
				PhoneNumber = candidate.PhoneNumber,
				PlaceOfBirth = candidate.PlaceOfBirth,
				ApplicationUserId = userId,
				DocumentId = documentId,
				AddressId = addressId
				

			};
			_dbContext.Candidates.Add(newCandidate);
			_dbContext.SaveChanges();


			//if success
			return RedirectToAction("Create", "Exams");
		}

		[HttpPost]
		public ActionResult AddAddress(CandidateViewModel candidate)
		{
			var address = new Address();
			return View();
		}




	}
}