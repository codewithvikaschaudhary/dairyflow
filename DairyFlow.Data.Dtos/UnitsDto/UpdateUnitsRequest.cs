using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Data.Dtos.UnitsDto
{
    public class UpdateUnitsRequest
    {

        public required string Name { get; set; }
        public required string ShortName { get; set; }
        public int ModifiedBy { get; set; }

    }
}
