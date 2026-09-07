using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Data.Models
{
    [Table("Inventories")]
    public class Inventories
    {
        [Column("id"), Key]
        public int Id { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }
        
        [Column("current_stock")]
        public decimal CurrentStock { get; set; }
        
        [Column("minimum_stock")]
        public decimal MinimumStock { get; set; }

        [Column("created_by")]
        public int CreatedBy { get; set; }
        
        [Column("created_date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Column("modified_by")]
        public int ModifiedBy { get; set; }

        [Column("modified_date")]
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
