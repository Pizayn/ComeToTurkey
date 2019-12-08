using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComeToTurkey.API.Models;

namespace ComeToTurkey.API.Dtos
{
    public class AboutPagesToReturnDto
    {
       
        public string AboutDescription { get; set; }
        public List<Team> Teams { get; set; }
    }
}
