using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Data.Dtos.UsersDto
{
    public class CreateUserRequest
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

    }
}
