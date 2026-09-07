using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Data.Dtos.CategoriesDto
{
    public class CategoriesResponse
    {

        public int Id { get; set; }
        public required string Name { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public required string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

    }
}
