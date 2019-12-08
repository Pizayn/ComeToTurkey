using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComeToTurkey.API.Models;

namespace ComeToTurkey.API.Dtos
{
    public class BlogForAdminDto
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string MainPhotoUrl { get; set; }
        public BlogCategoryToReturn BlogCategory { get; set; }
        public CityToReturnDto City { get; set; }
    }
}
