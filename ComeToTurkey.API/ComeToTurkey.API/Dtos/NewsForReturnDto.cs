using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComeToTurkey.API.Dtos
{
    public class NewsForReturnDto
    {
        public string Text { get; set; }
        public string Description { get; set; }
        public string MainPhotoUrl { get; set; }
        public string Title { get; set; }
    }
}
