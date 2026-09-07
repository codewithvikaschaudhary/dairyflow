using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Data.Dtos.InventoriesDto
{
    public class InventoriesResponse
    {

        public int Id { get; set; }
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public decimal CurrentStock { get; set; }
        public decimal MinimumStock { get; set; }
        public string? StockStatus { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public required string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

    }
}
