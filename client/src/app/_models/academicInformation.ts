import { Member } from "./member";

export interface AcademicInformation {
    id: number;
    appUser: Member;
    appUserId: number;
    currentDegreeProgram: string;
    yearOfStudy: string;
    expectedGraduationDate: string;
    overallGPA: number;
    majorGPA: number;
    completedCourses: string; // JSON string to store list of completed courses
    currentCourses: string;   // JSON string to store list of current courses
    favoriteSubjects: string; // JSON string to store list of favorite subjects
    leastFavoriteSubjects: string; // JSON string to store list of least favorite subjects
    technicalSkills: string;  // JSON string to store list of technical skills
    softSkills: string;       // JSON string to store list of soft skills
    certifications: string;   // JSON string to store list of certifications
    projects: string;         // JSON string to store list of projects
    internships: string;      // JSON string to store list of internships
    clubsAndOrganizations: string; // JSON string to store list of clubs and organizations
    volunteerExperience: string; // JSON string to store list of volunteer experience
    feedbackOnCurriculum: string;
  }
