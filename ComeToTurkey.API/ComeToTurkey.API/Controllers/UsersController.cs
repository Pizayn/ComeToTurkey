using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using ComeToTurkey.API.Data;
using ComeToTurkey.API.Dtos;
using ComeToTurkey.API.Helpers;
using ComeToTurkey.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComeToTurkey.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private IRepository _repo;
        private IMapper _mapper;

        public UsersController(IRepository repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            //önce destination sonra ise kaynak class gönderilir
            var user = await _repo.GetUser(id);
            var userToReturn = _mapper.Map<UserForDetailedDto>(user);
            return Ok(userToReturn);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();
            var usersToReturn = _mapper.Map<IEnumerable<UserListDto>>(users);
            return Ok(usersToReturn);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody]UserForUpdateDto userForUpdateDto)
        {
            //update edilecek profil token ile eşleşiyor mu
            //if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //{
            //    return Unauthorized();
            //}

            var userFromRepo = await _repo.GetUser(id);
            _mapper.Map(userForUpdateDto, userFromRepo);

            if (await _repo.SaveAll())
            {
                return NoContent();
            }
            throw new Exception($"Updating user {id} failed on save");
        }
        [HttpPost("{id}/follow/{recipientId}")]
        public async Task<IActionResult> FollowUser(int id, int recipientId)
        {
            //if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //{
            //    return Unauthorized();
            //}

            var follow = await _repo.GetFollow(id, recipientId);
            if (follow != null)
            {
                return BadRequest("You already follow this user");
            }

            if (await _repo.GetUser(recipientId) == null)
            {
                return NotFound();
            }

            follow = new Follow
            {
                FollowerId = id,
                FollowingId = recipientId
            };
            _repo.Add<Follow>(follow);
            if (await _repo.SaveAll())
            {
                return Ok();
            }

            return BadRequest("failed to follow user");
        }
        [HttpPost("{id}/isfollow/{recipientId}")]
        public async Task<IActionResult> IsFollowUser(int id, int recipientId)
        {
            //if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //{
            //    return Unauthorized();
            //}

            var follow = await _repo.GetFollow(id, recipientId);
            if (follow != null)
            {
                return BadRequest("You already follow this user");
            }

            return Ok();


        }

        [HttpDelete("{id}/unfollow/{recipientId}")]
        public async Task<IActionResult> UnFollowUser(int id, int recipientId)
        {
            var follow = await _repo.GetFollow(id, recipientId);

            
            _repo.UnFollow(follow);
            if (await _repo.SaveAll())
            {
                return Ok();
            }

            return BadRequest("failed to unfollow user");
        }

        [HttpGet("cities")]
        public async Task<IActionResult> GetCities()
        {
            var cities =await _repo.GetList<City>();
            return Ok(cities);
        }
        [HttpGet("blogcategories")]
        public async Task<IActionResult> GetBlogCategories()
        {
            var blogCategories = await _repo.GetList<BlogCategory>();
            return Ok(blogCategories);
        }
        [HttpGet("news")]
        public async Task<IActionResult> GetNews()
        {
            var news = await _repo.GetList<New>();
            return Ok(news);
        }

        [HttpGet("popularblogs")]
        public async Task<IActionResult> GetPopularBlogs()
        {
            var blogs = await _repo.GetPopularBlogs();
            return Ok(blogs);
        }

    }
}