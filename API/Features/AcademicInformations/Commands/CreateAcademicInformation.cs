using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using MediatR;

namespace API.Features.AcademicInformations.Commands
{
    public class CreateAcademicInformation
    {
        public class Command : IRequest<AcademicInformationDto> {
            public Command(AcademicInformationDto academicInformationDto)
            {
                AcademicInformationDto = academicInformationDto;
            }
            public AcademicInformationDto AcademicInformationDto { get; set; }
        }

        public class Handler : IRequestHandler<Command, AcademicInformationDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public  Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<AcademicInformationDto> Handle(Command command, CancellationToken cancellationToken)
            {
                if(command.AcademicInformationDto == null)
                {
                    throw new ArgumentNullException(nameof(command.AcademicInformationDto));
                }

                var academicInformation = _mapper.Map<AcademicInformation>(command.AcademicInformationDto);
                _context.AcademicInformations.Add(academicInformation);

                await _context.SaveChangesAsync();
                           
                var result = _mapper.Map<AcademicInformationDto>(academicInformation);

                return result;
            }
        }
    }
}