using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentRecruiter.Models.Domain
{
	public class Recruitment
	{
		public int Id { get; set; }	
		public int Slots { get; set; }
        public int FieldOfStudyId { get; set; }
	    public int StudyLevelId { get; set; }
	    public int StudyTypeId { get; set; }
        public int RecruitmentPhaseId { get; set; }
        public List<Subject> RequiredSubjects { get; set; }
	    public FieldOfStudy FieldOfStudy { get; set; }
	    public StudyLevel StudyLevel { get; set; }
	    public StudyType StudyType { get; set; }
	    public RecruitmentPhase RecruitmentPhase { get; set; }


    }
}