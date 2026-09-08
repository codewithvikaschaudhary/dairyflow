using DairyFlow.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Data.Dtos.PurchaseDto
{
    public class PurchasesResponse
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public required string SupplierName { get; set; }
        public required string InvoiceNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public PurchaseStatus Status { get; set; }
        public string? Notes { get; set; }
        public int CreatedBy { get; set; }
        public required string CreatedByName { get; set; }   
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public string? ModifiedByName { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
