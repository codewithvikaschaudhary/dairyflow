using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Data.Dtos.ProductsDto
{
    public class CreateProductsRequest
    {


        public required string Name { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }

    }
}
