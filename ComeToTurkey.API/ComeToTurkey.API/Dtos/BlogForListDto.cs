using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComeToTurkey.API.Dtos
{
    public class BlogForListDto
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
        public int BlogLikesCount { get; set; }

        public string UserLastName { get; set; }
        public string PhotoUrl { get; set; }
        public int BlogCategoryId { get; set; }
        public ICollection<CommentToReturnDto> CommentsReceived { get; set; }

       
    }
}
