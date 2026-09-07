using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Data.Models
{
    [Table("Users")]
    public class Users
    {
        [Column("id"), Key]
        public int Id { get; set; }
        [Column("first_name")]
        public required string FirstName { get; set; }
        [Column("last_name")]
        public required string LastName { get; set; }
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
