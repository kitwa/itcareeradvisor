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
            CreateMap<BlogPost, BlogPostDto>();
            CreateMap<BlogPostDto, BlogPost>();
            CreateMap<BlogPost, BlogPostUpdateDto>();
            CreateMap<BlogPostUpdateDto, BlogPost>();
            CreateMap<RegisterDto, AppUser>();

        }
    }
}