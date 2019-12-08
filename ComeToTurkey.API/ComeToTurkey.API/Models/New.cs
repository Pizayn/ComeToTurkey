using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComeToTurkey.API.Models
{
    public class New
    {
        public int NewId { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime CreatedTime { get; set; }
        public string MainPhotoUrl { get; set; }
    }
}
