using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Data.Dtos.PurchaseItemDto
{
    public class PurchaseItemFilters
    {
        public int? Id { get; set; }
        public int? PurchaseId { get; set; }
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

    }
}
