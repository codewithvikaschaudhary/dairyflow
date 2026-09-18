using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Data.Dtos.PurchaseItemDto
{
    public class PurchaseItemResponse
    {
        public int Id { get; set; }

        public int PurchaseId { get; set; }

        public required string InvoiceNumber { get; set; }

        public int ProductId { get; set; }

        public required string ProductName { get; set; }

        public decimal Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Discount { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal TotalAmount { get; set; }

        public required string CreatedByName { get; set; }
        
        public string? ModifiedByName { get; set; }

    }
}
