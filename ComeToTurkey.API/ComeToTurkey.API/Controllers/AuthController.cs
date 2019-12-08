using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ComeToTurkey.API.Data;
using ComeToTurkey.API.Dtos;
using ComeToTurkey.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ComeToTurkey.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private IAuthRepository _repo;
        private IConfiguration _configuration;
        private IMapper _mapper;

        public AuthController(IAuthRepository authRepository, IConfiguration configuration, IMapper mapper)
        {
            _repo = authRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto registerDto)
        {
            //modelstate
            registerDto.UserName = registerDto.UserName.ToLower();
            if (await _repo.UserExists(registerDto.UserName))
            {
                return BadRequest("Username already exists");
            }

            //var userToCreate = new User
            //{
            //    Username = registerDto.UserName,

            //};
            var userToCreate = _mapper.Map<User>(registerDto);
            var createdUser = await _repo.Register(userToCreate, registerDto.Password);
            var userToReturn = _mapper.Map<UserForDetailedDto>(createdUser);
            return Ok();
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _repo.Login(userForLoginDto.UserName, userForLoginDto.Password);
            if (userFromRepo == null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username),
            };
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var user = _mapper.Map<UserForDetailedDto>(userFromRepo);
            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                user

            });
        }


    }
}