using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class AcademicInformation
    {
        public int Id { get; set; }
        public AppUser appUser  { get; set; }
        public int AppUserId { get; set; }
        public string CurrentDegreeProgram { get; set; }
        public string YearOfStudy { get; set; }
        public DateOnly ExpectedGraduationDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public double OverallGPA { get; set; }
        public double MajorGPA { get; set; }
        public string CompletedCourses { get; set; }  // JSON string to store list of completed courses
        public string CurrentCourses { get; set; }    // JSON string to store list of current courses
        public string FavoriteSubjects { get; set; }    // JSON string to store list of current courses
        public string LeastFavoriteSubjects { get; set; }    // JSON string to store list of current courses
        public string TechnicalSkills { get; set; }    // JSON string to store list of current courses
        public string SoftSkills { get; set; }    // JSON string to store list of current courses
        public string Certifications { get; set; }    // JSON string to store list of current courses
        public string Projects { get; set; }    // JSON string to store list of current courses
        public string Internships { get; set; }    // JSON string to store list of current courses
        public string ClubsAndOrganizations { get; set; }    // JSON string to store list of current courses
        public string VolunteerExperience { get; set; }    // JSON string to store list of current courses
        public string FeedbackOnCurriculum { get; set; }

    }
}