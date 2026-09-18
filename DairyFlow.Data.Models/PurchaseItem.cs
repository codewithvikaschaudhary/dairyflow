using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Data.Models
{
    [Table("purchase_items")]
    public class PurchaseItem
    {

        [Column("id"), Key]
        public int Id { get; set; }

        [Column("purchase_id")]
        public int PurchaseId { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("quantity")]
        public decimal Quantity { get; set; }

        [Column("unit_price")]
        public decimal UnitPrice { get; set; }

        [Column("discount")]
        public decimal Discount { get; set; }

        [Column("tax_amount")]
        public decimal TaxAmount { get; set; }

        [Column("total_amount")]
        public decimal TotalAmount { get; set; }

        [Column("created_by")]
        public int CreatedBy { get; set; }

        [Column("created_date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Column("modified_by")]
        public int? ModifiedBy { get; set; }

        [Column("modified_date")]
        public DateTime? ModifiedDate { get; set; }

    }
}
