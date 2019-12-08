using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComeToTurkey.API.Dtos
{
    public class UserForDetailedDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryId { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string AboutMe { get; set; }
        public string Status { get; set; }
        public DateTime LastActive { get; set; }
        public string Gender { get; set; }
        public DateTime Created { get; set; }
        public string PhotoUrl { get; set; }

        public ICollection<FollowerDto> Followers { get; set; }
        public ICollection<PhotosForDetailedDto> Photos { get; set; }


    }
}
