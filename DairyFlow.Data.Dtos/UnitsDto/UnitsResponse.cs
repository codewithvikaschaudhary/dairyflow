using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Data.Dtos.UnitsDto
{
    public class UnitsResponse
    {

        public int Id { get; set; }
        public required string Name { get; set; }
        public required string ShortName { get; set; }
        public int CreatedBy { get; set; }
        public required string CreatedByName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? ModifiedBy { get; set; }
        public string? ModifiedByName { get; set; }
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;

    }
}
