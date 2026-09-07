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
    [Table("Stock_Transaction")]
    public class StockTransaction
    {
        [Column("id") , Key]
        public int Id { get; set; } 

        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("transaction_type")]
        public StockTransactionType TransactionType { get; set; }

        [Column("quantity")]
        public decimal Quantity { get; set; }
            
        [Column("reference_id")]
        public int? ReferenceId { get; set; }

        [Column("notes")]
        public string? Notes { get; set; }

        [Column("created_by")]
        public int CreatedBy { get; set; }
        
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }

    }
}
