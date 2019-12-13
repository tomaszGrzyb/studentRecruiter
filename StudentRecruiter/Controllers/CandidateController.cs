using StudentRecruiter.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentRecruiter.Controllers
{
    public class CandidateController : Controller
    {
        // GET: Candidate
        public ActionResult Index()
        {
            return View();
        }

		// POST: Candidate
		public ActionResult Create()
		{
			return View();
		}

		public ActionResult Edit(Candidate candidate)
		{
			return View();
		}

		
	}
}