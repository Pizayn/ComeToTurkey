using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComeToTurkey.API.Dtos
{
    public class DestinationForAdminDto
    {
        public int DestinationId { get; set; }
        public string RegionName { get; set; }
        public string MainPhotoUrl { get; set; }
        public string Text { get; set; }
        public CityToReturnDto City { get; set; }

    }
}
