using DairyFlow.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Data.Dtos.StockTransactionDto
{
    public class UpdateStockTransactionRequest
    {

        public int ProductId { get; set; }
        public StockTransactionType TransactionType { get; set; }
        public decimal Quantity { get; set; }
        public int? ReferenceId { get; set; }
        public string? Notes { get; set; }
        public int CreatedBy { get; set; }

    }
}
