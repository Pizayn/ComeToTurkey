using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ComeToTurkey.API.Data;
using ComeToTurkey.API.Dtos;
using ComeToTurkey.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComeToTurkey.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Admin")]
    public class AdminController : Controller
    {
        private IRepository _repository;
        private IMapper _mapper;

        public AdminController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAdminDashBoard()
        {
            var comments = await _repository.GetList<Comment>();
            var likes =await _repository.GetList<Like>();
            var blogs = await _repository.GetBlogList();
            var followers = await _repository.GetList<Follow>();
            var messages = await _repository.GetList<Message>();
            var users = await _repository.GetList<User>();
            var teams = await _repository.GetList<Team>();
            var photos = await _repository.GetList<Photo>();
            var destinations = await _repository.GetDestinationList();
            var blogCategories = await _repository.GetBlogCategories();
            var usersToReturn = _mapper.Map<List<UserForAdminDto>>(users);
            var blogsToReturn = _mapper.Map<List<BlogForAdminDto>>(blogs);
            var destinationToReturn = _mapper.Map<List<DestinationForAdminDto>>(destinations);
            var news = await _repository.GetList<New>();

            AdminDashboardToReturnDto adminDashboardToReturnDto =new AdminDashboardToReturnDto();
            adminDashboardToReturnDto.CommentCount = comments.Count();
            adminDashboardToReturnDto.BlogCount = blogs.Count();
            adminDashboardToReturnDto.FollowerCount = followers.Count();
            adminDashboardToReturnDto.UserCount = users.Count();
            adminDashboardToReturnDto.MessageCount = messages.Count();
            adminDashboardToReturnDto.LikeCount = likes.Count();
            adminDashboardToReturnDto.Teams = teams.ToList();
            adminDashboardToReturnDto.DestinationCount = destinations.Count();
            adminDashboardToReturnDto.PhotoCount = photos.Count();
            adminDashboardToReturnDto.BlogCategoryToReturns = blogCategories.ToList();
            adminDashboardToReturnDto.Users = usersToReturn;
            adminDashboardToReturnDto.Blogs = blogsToReturn;
            adminDashboardToReturnDto.Destinations = destinationToReturn;
            adminDashboardToReturnDto.News = news.ToList();





            var numbers =new List<int>();
            var strings = new List<string>();
            foreach (var item in blogCategories)
            {
                numbers.Add(item.BlogCategoryNameCount);
            }
            foreach (var item in blogCategories)
            {
                strings.Add(item.BlogCategoryNameCount.ToString());
            }

            adminDashboardToReturnDto.numbers = numbers;
            adminDashboardToReturnDto.strings = strings;







            return Ok(adminDashboardToReturnDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNews([FromBody]NewsForCreationDto newsForCreationDto)
        {
            //if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //{
            //    return Unauthorized();
            //}

            newsForCreationDto.Description = newsForCreationDto.Text.Substring(1, 100);
            var news = _mapper.Map<New>(newsForCreationDto);
            _repository.Add(news);
            if (await _repository.SaveAll())
            {
                return Ok();
            }

            return BadRequest();

        }
        [HttpGet("{newId}")]
        public async Task<IActionResult> GetNews(int newId)
        {
            //if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //{
            //    return Unauthorized();
            //}
            var news = await _repository.GetNews(newId);
            var newsToReturn = _mapper.Map<NewsForReturnDto>(news);
            return Ok(newsToReturn);
        }
    }
}
