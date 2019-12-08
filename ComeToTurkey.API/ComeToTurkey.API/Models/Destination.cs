using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComeToTurkey.API.Models
{
    public class Destination
    {
        public int DestinationId { get; set; }
        public string RegionName { get; set; }
        public string MainPhotoUrl { get; set; }
        public string Text { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
