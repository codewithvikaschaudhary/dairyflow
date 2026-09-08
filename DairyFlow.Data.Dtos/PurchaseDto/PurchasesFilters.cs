using DairyFlow.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Data.Dtos.PurchaseDto
{
    public class PurchasesFilters
    {

        public int? Id { get; set; }

        public int? SupplierId { get; set; }

        public string? InvoiceNumber { get; set; }

        public PurchaseStatus? Status { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? PurchaseDateFrom { get; set; }

        public DateTime? PurchaseDateTo { get; set; }

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;

    }
}
