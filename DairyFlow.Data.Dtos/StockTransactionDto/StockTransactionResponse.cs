using DairyFlow.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Data.Dtos.StockTransactionDto
{
    public class StockTransactionResponse
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public required string ProductName { get; set; }

        public StockTransactionType TransactionType { get; set; }

        public decimal Quantity { get; set; }

        public int? ReferenceId { get; set; }

        public string? Notes { get; set; }

        public required string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
