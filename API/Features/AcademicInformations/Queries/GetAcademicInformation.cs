using API.Data;
using API.DTOs;
using API.Entities;
using API.Helpers;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Features.AcademicInformations.Queries
{
    public abstract class GetAcademicInformation
    {
        public class Query : IRequest<AcademicInformationDto> 
        {
            public Query (int appUserId) 
            {
                AppUserId = appUserId;
            }

            public int AppUserId {get; set;}
        }

        public class Handler: IRequestHandler<Query, AcademicInformationDto> 
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public  Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<AcademicInformationDto> Handle(Query query, CancellationToken cancellationToken)
            {
                var academicInformation = await _context.AcademicInformations.Where(x => x.AppUserId == query.AppUserId).SingleOrDefaultAsync();

                if(academicInformation == null){
                    academicInformation = new AcademicInformation();
                    academicInformation.AppUserId = query.AppUserId;
                    _context.AcademicInformations.Add(academicInformation);
                    _context.SaveChanges();
                }
                            
                return _mapper.Map<AcademicInformationDto>(academicInformation);
            }
        }
        
    }
}