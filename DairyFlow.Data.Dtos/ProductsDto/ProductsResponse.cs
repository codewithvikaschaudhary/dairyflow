using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DairyFlow.Data.Dtos.ProductsDto
{
    public class ProductsResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public int BrandId { get; set; }
        public required string BrandName { get; set; }
        public required string CreatedBy { get; set; }
        // need to ignore these properties when serializing to JSON, as they are not needed in the response
        [JsonIgnore]
        public string? CreatedByFirstName { get; set; }
        // need to ignore these properties when serializing to JSON, as they are not needed in the response
        [JsonIgnore]
        public string? CreatedByLastName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public required string ModifiedBy { get; set; }
        // need to ignore these properties when serializing to JSON, as they are not needed in the response
        [JsonIgnore]
        public string? ModifiedByFirstName { get; set; }
        // need to ignore these properties when serializing to JSON, as they are not needed in the response
        [JsonIgnore]
        public string? ModifiedByLastName { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;


    }
}
