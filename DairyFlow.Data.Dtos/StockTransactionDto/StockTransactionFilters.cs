using DairyFlow.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Data.Dtos.StockTransactionDto
{
    public class StockTransactionFilters
    {
        public int? Id { get; set; }
        public int? ProductId { get; set; }
        public StockTransactionType? TransactionType { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int PageCount { get; set; }

    }
}
