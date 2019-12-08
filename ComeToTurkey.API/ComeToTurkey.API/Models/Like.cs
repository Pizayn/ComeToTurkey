using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComeToTurkey.API.Models
{
    public class Like
    {
        public int LikerId { get; set; }
        public int BlogLikeId { get; set; }
        public User Liker { get; set; }
        public Blog BlogLike { get; set; }
    }
}
