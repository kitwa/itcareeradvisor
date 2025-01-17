using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Constants;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, 
            ITokenService tokenService, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _tokenService = tokenService;

        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {

            if (await EmailExists(registerDto.Email)) return BadRequest("Email Taken");

            var user = _mapper.Map<AppUser>(registerDto);

            user.Email = registerDto.Email.ToLower();

            var password = "Lind@2024";
            var result = await _userManager.CreateAsync(user, password);

            if(!result.Succeeded) return BadRequest(result.Errors);

            var roleResult =  await _userManager.AddToRoleAsync(user, "Member"); 

            if(!roleResult.Succeeded) return BadRequest(result.Errors);


            return new UserDto
            {
                Email = user.Email,
                Token = await _tokenService.CreateToken(user),
                Id = user.Id
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.Email == loginDto.Email.ToLower());

            if (user == null) return Unauthorized("Wrong login details");

            if(await _userManager.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower()) == null) return Unauthorized("Wrong Student Number");

            var password = "Lind@2024";

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if(!result.Succeeded) return Unauthorized("Incorrect Login details");

            return new UserDto
            {
                Email = user.Email,
                Token = await  _tokenService.CreateToken(user),
                Id = user.Id
            };
        }

        private async Task<bool> EmailExists(string email)
        {
            return await _userManager.Users.AnyAsync(x => x.Email == email.ToLower());
        }

    }
}