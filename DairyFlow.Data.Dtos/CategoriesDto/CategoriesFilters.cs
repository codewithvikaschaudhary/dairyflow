using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Data.Dtos.CategoriesDto
{
    public class CategoriesFilters
    {

        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int PageCount { get; set; }
    }
}
