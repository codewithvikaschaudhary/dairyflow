using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Data.Models
{
    [Table ("Units")]
    public class Units
    {
        [Column("Id"),Key]
        public int Id { get; set; }
        [Column("name")]
        public required string Name { get; set; }
        [Column("short_name")]
        public required string ShortName { get; set; }
        [Column("created_by")]
        public int CreatedBy { get; set; }
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }
        [Column("modified_by")]
        public int? ModifiedBy { get; set; }
        [Column("modified_date")]
        public DateTime? ModifiedDate { get; set; }

    }
}
