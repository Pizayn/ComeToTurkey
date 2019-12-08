using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComeToTurkey.API.Helpers
{
    public class BlogParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        //propfull 
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
            //eğer kullanıcı 30 kişiyi görmek isterse görür ama 50 yi geçemez
        }

        public int UserId { get; set; }
       
        public string OrderBy { get; set; }
        public int BlogCategoryId { get; set; }
        public bool Likees { get; set; } = false;
        public bool Likers { get; set; } = false;
    }
}
