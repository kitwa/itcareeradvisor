using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Features.BlogPosts.Commands;
using API.Features.BlogPosts.Queries;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class BlogPostsController : BaseApiController
    {
        public readonly IMediator _mediator;
        private readonly DataContext _context;
        public BlogPostsController(DataContext context, IMediator mediator)
        {
            _mediator = mediator;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPostDto>>> GetBlogs([FromQuery]UserParams userParams)
        {
            var blogPosts = await _mediator.Send(new GetBlogPosts.Query(userParams));
            
            Response.AddPaginationHeader(blogPosts.CurrentPage, blogPosts.PageSize, blogPosts.TotalCount, blogPosts.TotalPages);    
            return Ok(blogPosts);
        }


        [HttpGet("{id}", Name = "GetBlogPost")]
        public async Task<ActionResult<BlogPostDto>> GetBlogPost(int id)
        {
            var blogPost = await _mediator.Send(new GetBlogPost.Query(id));
            if(blogPost != null) {
                return blogPost;
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBlogPost(int id, BlogPostUpdateDto blogPostUpdateDto)
        {
            var blogPost = await _mediator.Send(new UpdateBlogPost.Command(id, blogPostUpdateDto));

            if(blogPost != null){
                return Ok(blogPost);
            }
            return BadRequest("Failed to create blogPost");
        }

        [Authorize(Policy = "RequireAdminAgentRole")]
        [HttpPost]
        public async Task<ActionResult<BlogPostDto>> CreateBlogPost(BlogPostDto blogPostDto)
        {
            var blogPost = await _mediator.Send(new CreateBlogPost.Command(blogPostDto));

            if(blogPost != null){
                return Ok(blogPost);
            }
            return BadRequest("Failed to create blogPost");

        }


        [Authorize(Policy = "RequireAdminAgentRole")]
        [HttpPut("{id:int}/delete")]
        public async Task<ActionResult> DeleteBlogPost(int id)
        {
            var blogPost = await _context.BlogPosts.FindAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }

            _context.BlogPosts.Remove(blogPost);
            await _context.SaveChangesAsync();

            // use cloudinary publicId to delete on cloudinary

            return NoContent();
        }

    }
}