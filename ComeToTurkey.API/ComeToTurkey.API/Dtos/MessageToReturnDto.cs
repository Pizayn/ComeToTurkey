﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComeToTurkey.API.Dtos
{
    public class MessageToReturnDto
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public string SenderFirstName { get; set; }
        public int RecipientId { get; set; }
        public string RecipientFirstName { get; set; }

        public string SenderPhotoUrl { get; set; }
        public string RecipientPhotoUrl { get; set; }
        public DateTime? DateRead { get; set; }

        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
        public string Content { get; set; }
    }
}
