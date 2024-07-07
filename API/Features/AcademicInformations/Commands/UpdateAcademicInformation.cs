using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using MediatR;

namespace API.Features.AcademicInformations.Commands
{
    public class UpdateAcademicInformation
    {
        public class Command : IRequest<AcademicInformationUpdateDto> {
            public Command(int id, AcademicInformationUpdateDto academicInformationUpdateDto)
            {
                AppUserId = id;
                AcademicInformationUpdateDto = academicInformationUpdateDto;
            }
            public AcademicInformationUpdateDto AcademicInformationUpdateDto { get; set; }
            public int AppUserId { get; set; }
        }

        public class Handler : IRequestHandler<Command, AcademicInformationUpdateDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public  Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<AcademicInformationUpdateDto> Handle(Command command, CancellationToken cancellationToken)
            {
                if(command.AcademicInformationUpdateDto == null)
                {
                    throw new ArgumentNullException(nameof(command.AcademicInformationUpdateDto));
                }
                var academicInformation = _context.AcademicInformations.FirstOrDefault(p => p.AppUserId == command.AppUserId);

               _mapper.Map(command.AcademicInformationUpdateDto, academicInformation);

                _context.AcademicInformations.Update(academicInformation);

                await _context.SaveChangesAsync();
                           
                var result = _mapper.Map<AcademicInformationUpdateDto>(academicInformation);

                return result;
            }
        }
    }
}