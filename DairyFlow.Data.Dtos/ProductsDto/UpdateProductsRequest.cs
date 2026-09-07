using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Data.Dtos.ProductsDto
{
    public class UpdateProductsRequest
    {

        public required string Name { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

    }
}
