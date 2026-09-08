using DairyFlow.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Data.Dtos.PurchaseDto
{
    public class UpdatePurchasesRequest
    {
        public int SupplierId { get; set; }
        public required string InvoiceNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public PurchaseStatus Status { get; set; }
        public string? Notes { get; set; }
        public int ModifiedBy { get; set; }
    }
}
