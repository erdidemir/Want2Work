using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Infrastructure.Queries.Commons
{
    public class PageQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PageQuery()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public PageQuery(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}
