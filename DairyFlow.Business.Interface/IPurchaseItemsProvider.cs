using DairyFlow.Data.Dtos.PurchaseDto;
using DairyFlow.Data.Dtos.PurchaseItemDto;
using DairyFlow.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Business.Interfaces
{
    public interface IPurchaseItemsProvider
    {
        PurchaseItemResponse GetPurchaseItemById(int id);
        List<PurchaseItemResponse> GetAllPurchaseItems(PurchaseItemFilters filters);
        Task<PurchaseItem> CreatePurchaseItem(CreatePurchaseItemRequest request);
        Task<PurchaseItem> UpdatePurchaseItem(int id, UpdatePurchaseItemRequest request);
        Task<int> DeletePurchaseItem(int id);


    }
}
