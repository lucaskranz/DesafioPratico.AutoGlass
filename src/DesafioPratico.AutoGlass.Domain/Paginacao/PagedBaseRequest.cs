using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPratico.AutoGlass.Domain.Paginacao
{    
    public class PagedBaseRequest
    {
        public PagedBaseRequest()
        {
            Page = 1;
            PageSize = 10;
            OrderProperty = "Id";
        }

        public int Page { get; set; }
        public int PageSize { get; set; }
        public string OrderProperty { get; set; }

    }
}
