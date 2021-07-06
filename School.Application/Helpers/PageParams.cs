using System;
using System.Collections.Generic;
using System.Text;

namespace School.Application.Helpers
{
    public class PageParams
    {
        public const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        public int PageSize 
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }

        public string Name { get; set; } = string.Empty;
        public int? Enrolment { get; set; } = null;
        public int? Active { get; set; } = null;
    }
}
