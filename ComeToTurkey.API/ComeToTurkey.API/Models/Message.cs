using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComeToTurkey.API.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public User Sender { get; set; }
        public int RecipientId { get; set; }
        public User Recipient { get; set; }

        public DateTime? DateRead { get; set; }

        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }

        public bool IsDeletedBySender { get; set; }
        public bool IsDeletedByRecipient { get; set; }
        public string Content { get; set; }
    }
}
