namespace API.DTOs
{
    public class MemberUpdateDto
    {
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
    }
}