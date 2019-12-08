using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComeToTurkey.API.Models
{
    public class BlogCategory
    {
        public int BlogCategoryId { get; set; }
        public string BlogCategoryName { get; set; }
        public ICollection<Blog> Blogs { get; set; }

    }
}
