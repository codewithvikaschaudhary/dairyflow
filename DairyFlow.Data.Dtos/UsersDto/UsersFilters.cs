using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Data.Dtos.UsersDto
{
    public class UsersFilters
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int PageNumber { get; set; } = 1; 
        public int PageSize { get; set; } = 10;
        public int PageCount { get; set; }

    }
}
