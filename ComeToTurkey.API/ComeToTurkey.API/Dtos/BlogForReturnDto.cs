using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComeToTurkey.API.Models;

namespace ComeToTurkey.API.Dtos
{
    public class BlogForReturnDto
    {
        public int BlogId { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public string MainPhotoUrl { get; set; }
        public string UserFirstName { get; set; }
        public int CommentsReceivedCount { get; set; }
        public string UserLastName { get; set; }
        public string PhotoUrl { get; set; }
        public int BlogLikesCount { get; set; }
        public BlogCategoryToReturn BlogCategory { get; set; }
        public CityToReturnDto City { get; set; }
        public ICollection<CommentToReturnDto> CommentsReceived { get; set; }
        public ICollection<LikeToReturnDto> BlogLikes { get; set; }

    }
}
