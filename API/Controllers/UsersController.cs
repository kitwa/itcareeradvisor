using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository, IMapper mapper, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [Authorize(Policy = "RequireAdminAgentRole")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers([FromQuery] UserParams userParams)
        {
            userParams.CurrentEmail = User.GetEmail();
            var users = await _userRepository.GetMembersAsync(userParams);

            Response.AddPaginationHeader(users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPages);

            return Ok(users);
        }

        [Authorize(Policy = "RequireAdminAgentRole")]
        [HttpGet("agents")]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetAgents([FromQuery] UserParams userParams)
        {
            var agents = await _userManager.GetUsersInRoleAsync("Agent");
            _mapper.Map<IEnumerable<MemberDto>>(agents);
            return Ok(agents);

        }

        // [HttpGet("{id}", Name= "GetUser")]
        // public async Task<ActionResult<MemberDto>> GetUser(int id)
        // {
        //     // var user = await _userRepository.GetUserByUsernameAsync(username);
        //     // return _mapper.Map<MemberDto>(user);

        //     return await _userRepository.GetMemberAsync(id);
        // }

        [HttpGet("{email}", Name = "GetUserByEmail")]
        public async Task<ActionResult<MemberDto>> GetUser(string email)
        {
            // var user = await _userRepository.GetUserByUsernameAsync(username);
            // return _mapper.Map<MemberDto>(user);

            return await _userRepository.GetMemberAgentAsync(email);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
        {
            var user = await _userRepository.GetUserByEmailAsync(User.GetEmail());

            _mapper.Map(memberUpdateDto, user);

            _userRepository.Update(user);

            if (await _userRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update user");
        }

        // [HttpPost("add-photo")]
        // public async Task<ActionResult<PhotoDto>> AddPhoto(IFormFile file)
        // {
        //     var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());

        //     var result = await _photoService.AddPhotoAsync(file);

        //     if(result.Error != null) return BadRequest(result.Error.Message);

        //     var photo = new Photo{
        //         Url = result.SecureUrl.AbsoluteUri,
        //         PublicId = result.PublicId
        //     };

        //     if(user.Photos.Count == 0)
        //     {
        //         photo.IsMain = true;
        //     }

        //     user.Photos.Add(photo); 

        //     if(await _userRepository.SaveAllAsync()){

        //     // return _mapper.Map<PhotoDto>(photo);

        //     // return Created("GetUser", _mapper.Map<PhotoDto>(photo));
        //     return CreatedAtRoute("GetUser",new{Username = user.UserName} ,_mapper.Map<PhotoDto>(photo));

        //     } 

        //     return BadRequest("There was an issue adding the photo");

        // }

    }


}