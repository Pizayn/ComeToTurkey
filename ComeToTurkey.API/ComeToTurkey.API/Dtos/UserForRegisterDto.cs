using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComeToTurkey.API.Dtos
{
    public class UserForRegisterDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryId { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AboutMe { get; set; }
        public string Status { get; set; }
        public DateTime LastActive { get; set; }
        public string Gender { get; set; }
        public DateTime Created { get; set; }

        public UserForRegisterDto()
        {
            Created = DateTime.Now;
            LastActive = DateTime.Now;
        }
    }
}
