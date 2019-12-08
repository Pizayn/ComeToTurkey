using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComeToTurkey.API.Models;

namespace ComeToTurkey.API.Dtos
{
    public class AdminDashboardToReturnDto
    {
        public int MessageCount { get; set; }
        public int FollowerCount { get; set; }
        public int UserCount { get; set; }
        public int BlogCount { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public int DestinationCount { get; set; }
        public int PhotoCount { get; set; }
        public List<Team> Teams { get; set; }
        public List<BlogCategoryToReturnDto> BlogCategoryToReturns { get; set; }
        public List<New> News { get; set; }
        public ICollection<UserForAdminDto> Users { get; set; }
        public ICollection<BlogForAdminDto> Blogs { get; set; }
        public ICollection<DestinationForAdminDto> Destinations { get; set; }
        public List<int> numbers { get; set; }
        public List<string> strings { get; set; }
    }
}
