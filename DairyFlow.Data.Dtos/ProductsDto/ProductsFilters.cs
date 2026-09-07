using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Data.Dtos.ProductsDto
{
    public class ProductsFilters
    {

        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? CategoryName { get; set; }
        public string? BrandName { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int PageCount { get; set; }

    }
}
