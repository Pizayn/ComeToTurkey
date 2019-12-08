using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComeToTurkey.API.Dtos
{
    public class UserForUpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryId { get; set; }
        public string Email { get; set; }
        public string AboutMe { get; set; }
        public string Status { get; set; }
    }
}
