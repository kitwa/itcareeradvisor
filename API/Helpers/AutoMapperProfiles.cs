using System.Linq;
using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>();
            CreateMap<MemberUpdateDto, AppUser>();
            CreateMap<AcademicInformation, AcademicInformationDto>();
            CreateMap<AcademicInformationDto, AcademicInformation>();
            CreateMap<AcademicInformation, AcademicInformationUpdateDto>();
            CreateMap<AcademicInformationUpdateDto, AcademicInformation>();
            CreateMap<RegisterDto, AppUser>();

        }
    }
}