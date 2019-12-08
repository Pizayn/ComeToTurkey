using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComeToTurkey.API.Dtos
{
    public class CommentsForCreationDto
    {
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
        public CommentsForCreationDto()
        {
            SendDate = DateTime.Now;
        }
    }
}
