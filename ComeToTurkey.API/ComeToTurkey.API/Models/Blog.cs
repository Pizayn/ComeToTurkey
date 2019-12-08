using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComeToTurkey.API.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public string MainPhotoUrl { get; set; }
        public int BlogCategoryId { get; set; }
        public User User { get; set; }
        public BlogCategory BlogCategory { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public ICollection<Comment> CommentsReceived { get; set; }
        public ICollection<Like> BlogLikes { get; set; }

    }
}
