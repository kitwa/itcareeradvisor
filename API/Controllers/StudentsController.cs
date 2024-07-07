using API.Data;
using API.DTOs;
using API.Features.AcademicInformations.Commands;
using API.Features.AcademicInformations.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class StudentsController : BaseApiController
    {
        public readonly IMediator _mediator;
        private readonly DataContext _context;
        public StudentsController(DataContext context, IMediator mediator)
        {
            _mediator = mediator;
            _context = context;
        }

        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<AcademicInformationDto>>> GetBlogs([FromQuery]UserParams userParams)
        // {
        //     var blogPosts = await _mediator.Send(new GetBlogPosts.Query(userParams));
            
        //     Response.AddPaginationHeader(blogPosts.CurrentPage, blogPosts.PageSize, blogPosts.TotalCount, blogPosts.TotalPages);    
        //     return Ok(blogPosts);
        // }


        [HttpGet("{id:int}/get-academic-information")]
        public async Task<ActionResult<AcademicInformationDto>> GetAcademicInformation(int id)
        {
            var academicInformation = await _mediator.Send(new GetAcademicInformation.Query(id));
            return academicInformation;
        }

        [HttpPut("{id}/edit-academic-information")]
        public async Task<ActionResult> UpdateAcademicInformation(int id, AcademicInformationUpdateDto academicInformationUpdateDto)
        {
            var academicInformation = await _mediator.Send(new UpdateAcademicInformation.Command(id, academicInformationUpdateDto));

            if(academicInformation != null){
                return Ok(academicInformation);
            }
            return BadRequest("Failed to update");
        }

        [HttpPost]
        public async Task<ActionResult<AcademicInformationDto>> CreateAcademicInformation(AcademicInformationDto academicInformationDto)
        {
            var academicInformation = await _mediator.Send(new CreateAcademicInformation.Command(academicInformationDto));

            if(academicInformation != null){
                return Ok(academicInformation);
            }
            return BadRequest("Failed to create");

        }

    }
}