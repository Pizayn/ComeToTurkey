using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComeToTurkey.API.Dtos
{
    public class BlogForCreationDto
    {
        public string Text { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public string MainPhotoUrl { get; set; }
        public string Title { get; set; }
        public int BlogCategoryId { get; set; }
        public int CityId { get; set; }

        public BlogForCreationDto()
        {
            this.CreatedTime=DateTime.Now;
        }
       
    }
}
