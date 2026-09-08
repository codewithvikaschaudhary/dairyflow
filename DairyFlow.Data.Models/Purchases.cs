using DairyFlow.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Data.Models
{
    [Table("Purchases")]
    public class Purchases
    {
        [Column("id"), Key]
        public int Id { get; set; }

        [Column("supplier_id")]
        public int SupplierId { get; set; }

        [Column("invoice_number")]
        public string InvoiceNumber { get; set; } = null!;

        [Column("purchase_date")]
        public DateTime PurchaseDate { get; set; } = DateTime.Now;

        [Column("total_amount")]
        public decimal TotalAmount { get; set; }

        [Column("discount")]
        public decimal Discount { get; set; }

        [Column("tax_amount")]
        public decimal TaxAmount { get; set; }

        [Column("final_amount")]
        public decimal FinalAmount { get; set; }

        [Column("status")]
        public PurchaseStatus Status { get; set; }

        [Column("notes")]
        public string? Notes { get; set; }

        [Column("created_by")] 
        public int CreatedBy { get; set; }

        [Column("created_date")]
        public DateTime CreatedDate { get; set; }

        [Column("modified_by")]
        public int? ModifiedBy { get; set; }

        [Column("modified_date")]
        public DateTime ModifiedDate { get; set; }

    }
}
