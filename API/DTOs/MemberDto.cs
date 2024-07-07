using System;
using System.Collections.Generic;

namespace API.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string LanguagesSpoken { get; set; }
        public string PersonalityTraits { get; set; }
        public string LearningStyle { get; set; }
        public string HobbiesAndInterests { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
    }
}