﻿using StudentRecruiter.Models.Domain;
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
                .Include(c => c.Address)
                .Include(c => c.Document)
                .Single();

            return View(candidate);
        }

        [HttpGet]
        public ActionResult Create()
		{
            var candidateViewModel = new CandidateViewModel();
			candidateViewModel.DocumentTypes = _dbContext.DocumentTypes.ToList();

			return View(candidateViewModel);
		}

        [HttpPost]
        public ActionResult Create(CandidateViewModel candidate)
        {
            var userId = User.Identity.GetUserId();
            var newCandidate = new CandidateDetails()
            {
                SecondName = candidate.SecondName,
                DateOfBirth = candidate.DateOfBirth,
                Pesel = candidate.Pesel,
                PhoneNumber = candidate.PhoneNumber,
                PlaceOfBirth = candidate.PlaceOfBirth,
                ApplicationUserId = userId
            };

            //_dbContext.Candidates.Add(newCandidate);
            //_dbContext.SaveChanges();
            
            //if success
            return View();
        }

        [HttpPost]
        public ActionResult AddAddress(CandidateViewModel candidate)
        {
            var address = new Address();
            return View();
        }

        [HttpPost]
        public ActionResult Edit()
		{
		    var userId = User.Identity.GetUserId();
		    var candidate = _dbContext.Candidates
		        .Where(c => c.ApplicationUserId == userId)
		        .Include(c => c.Address)
		        .Include(c => c.Document)
		        .Single();

            return View(candidate);
		}

		
	}
}