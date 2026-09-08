using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Data.Dtos.SuppliersDto
{
    public class CreateSuppliersRequest
    {

        public required string Name { get; set; }

        public required string Phone { get; set; }

        public string? Email { get; set; }

        public required string Address { get; set; }

        public int CreatedBy { get; set; }

    }
}
