using System;
using System.Collections.Generic;
using System.Linq;
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
    [Route("api/users/{userId}/comments")]
    public class CommentsController : Controller
    {
        private IRepository _repo;
        private IMapper _mapper;

        public CommentsController(IMapper mapper, IRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetCommentsToBlog([FromQuery]CommentParams commentParams)

        {
            //if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //{
            //    return Unauthorized();
            //}
            var commentsFromRepo = await _repo.GetCommentsForUser(commentParams);
            var comments = _mapper.Map<IEnumerable<CommentToReturnDto>>(commentsFromRepo);
            Response.AddPagination(commentsFromRepo.CurrentPage, commentsFromRepo.PageSize, commentsFromRepo.TotalCount, commentsFromRepo.TotalPages);
            return Ok(comments);

        }
        [HttpGet("{id}", Name = "GetComment")]
        public async Task<IActionResult> GetComment(int userId, int id)
        {
            //if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //{
            //    return Unauthorized();
            //}
            var commentFromRepo = await _repo.GetComment(id);
            if (commentFromRepo == null)
            {
                return BadRequest("Message could not find");
            }
            var messageToReturn = _mapper.Map<CommentsForCreationDto>(commentFromRepo);
            return Ok(messageToReturn);
        }
        [HttpPost]
        public async Task<IActionResult> CreateComment(int userId, [FromBody]CommentsForCreationDto commentsForCreationDto)
        {
            var sender = await _repo.GetUser(userId);

            //if (sender.Id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //{
            //    return Unauthorized();
            //}
            commentsForCreationDto.SenderId = userId;
          
            var comment = _mapper.Map<Comment>(commentsForCreationDto);
            _repo.Add(comment);
            if (await _repo.SaveAll())
            {
                var commentToReturn = _mapper.Map<CommentToReturnDto>(comment);
                return CreatedAtRoute("GetComment", new { id = comment.Id }, commentToReturn);
            }
            throw new Exception("Creating the message failed on save");
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteComment(int id, int userId)
        {
            //if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //{
            //    return Unauthorized();
            //}
            var comment = await _repo.GetComment(id);
            if (comment.SenderId == userId)
            {
                comment.IsDeletedBySender = true;
            }
          
                comment.IsDeletedByRecipient = true;
            
            if (comment.IsDeletedByRecipient && comment.IsDeletedBySender)
            {
                _repo.Delete(comment);
            }
            if (await _repo.SaveAll())
                return NoContent();
            throw new Exception("Error deleting the message");
        }
    }
}