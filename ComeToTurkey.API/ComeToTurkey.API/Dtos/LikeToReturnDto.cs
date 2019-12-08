using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComeToTurkey.API.Dtos
{
    public class LikeToReturnDto
    {
        public int LikerId { get; set; }
        public string LikerFirstName { get; set; }
        public string LikerLastName { get; set; }
        public string SenderPhotoUrl { get; set; }

    }
}
