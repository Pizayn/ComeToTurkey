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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComeToTurkey.API.Controllers
{
    [Produces("application/json")]
    [Route("api/users/{userId}/blogs")]
    public class BlogsController : Controller
    {
        private IRepository _repo;
        private IMapper _mapper;

        public BlogsController(IRepository repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        [HttpGet("{blogId}",Name = "GetBlog")]
        public async Task<IActionResult> GetBlog(int blogId)
        {
            //if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //{
            //    return Unauthorized();
            //}
            var blog =await _repo.GetBlog(blogId);
            var blogToReturn = _mapper.Map<BlogForReturnDto>(blog);
            return Ok(blogToReturn);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(int userId,[FromBody]BlogForCreationDto blogForCreationDto)
        {
            //if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //{
            //    return Unauthorized();
            //}
         
            var user = await _repo.GetUser(userId);
            blogForCreationDto.Description = blogForCreationDto.Text.Substring(1, 10);
            var blog = _mapper.Map<Blog>(blogForCreationDto);
            user.Blogs.Add(blog);
            if (await _repo.SaveAll())
            {
                return Ok();
            }

            return BadRequest();

        }

      
        [HttpDelete("{blogId}")]
        public async Task<IActionResult> DeleteBlog(int userId, int blogId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }
            var blog =await _repo.GetBlog(blogId);
            _repo.Delete(blog);
            if (await _repo.SaveAll())
            {
                return Ok();
            }

            return BadRequest();

        }



        [HttpGet]
        public async Task<IActionResult> GetBlogs(int userId,[FromQuery]BlogParams blogParams)
        {
            //if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //{
            //    return Unauthorized();
            //}

            //var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var userFromRepo = await _repo.GetUser(userId);
            blogParams.UserId = userId;
           
            var blogs = await _repo.GetBlogs(blogParams);
            Response.AddPagination(blogs.CurrentPage, blogs.PageSize, blogs.TotalCount, blogs.TotalPages);
            var blogToReturn = _mapper.Map<IEnumerable<BlogForListDto>>(blogs);
            return Ok(blogToReturn);

        }

        [HttpPost("{blogId}/like")]
        public async Task<IActionResult> LikeBlog(int userId, int blogId)
        {
            //if (id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //{
            //    return Unauthorized();
            //}

            var like = await _repo.GetBlogLike(userId, blogId);
            if (like != null)
            {
                return BadRequest("You already follow this user");
            }

            if (await _repo.GetBlog(blogId) == null)
            {
                return NotFound();
            }

            like = new Like
            {
                LikerId = userId,
                BlogLikeId = blogId
            };
            _repo.Add<Like>(like);
            if (await _repo.SaveAll())
            {
                return Ok();
            }

            return BadRequest("failed to follow user");
        }
       
        [HttpDelete("{blogId}/unlike")]
        public async Task<IActionResult> UnLike(int userId, int blogId)
        {
            var like = await _repo.GetBlogLike(userId, blogId);


            _repo.Delete(like);
            if (await _repo.SaveAll())
            {
                return Ok();
            }

            return BadRequest("failed to unfollow user");
        }

    }
}