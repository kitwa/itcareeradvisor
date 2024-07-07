using System;
using System.Collections.Generic;
using API.Entities;

namespace API.DTOs
{
    public class AcademicInformationUpdateDto
    {
        public int AppUserId { get; set; }
        public MemberDto appUser {get; set; }
        public string CurrentDegreeProgram { get; set; }
        public string YearOfStudy { get; set; }
        public DateOnly ExpectedGraduationDate { get; set; }
        public double OverallGPA { get; set; }
        public double MajorGPA { get; set; }
        public string CompletedCourses { get; set; }  
        public string CurrentCourses { get; set; }    
        public string FavoriteSubjects { get; set; }    
        public string LeastFavoriteSubjects { get; set; }    
        public string TechnicalSkills { get; set; }    
        public string SoftSkills { get; set; }    
        public string Certifications { get; set; }    
        public string Projects { get; set; }    
        public string Internships { get; set; }    
        public string ClubsAndOrganizations { get; set; }    
        public string VolunteerExperience { get; set; }    
        public string FeedbackOnCurriculum { get; set; }
        public bool Deleted { get; set; }

    }
}
