using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public DateOnly DateOfBirth { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public string Nationality { get; set; }
        public string LanguagesSpoken { get; set; }
        public string PersonalityTraits { get; set; }
        public string LearningStyle { get; set; }
        public string HobbiesAndInterests { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public bool Deleted { get; set; }

    }
}