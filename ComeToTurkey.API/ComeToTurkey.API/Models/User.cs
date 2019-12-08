using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComeToTurkey.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryId { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AboutMe { get; set; }
        public string Status { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime LastActive { get; set; }
        public string Gender { get; set; }
        public DateTime Created { get; set; }
        public Country Country { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<Message> MessagesSent { get; set; }
        public ICollection<Message> MessagesReceived { get; set; }
        public ICollection<Blog> Blogs { get; set; }
        public ICollection<Follow> Followers { get; set; }
        public ICollection<Follow> Followings { get; set; }
        public ICollection<Comment> CommentsSent { get; set; }
        public ICollection<Like> Likers { get; set; }


    }
}
