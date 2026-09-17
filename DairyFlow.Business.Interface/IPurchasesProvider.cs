using DairyFlow.Data.Dtos.ProductsDto;
using DairyFlow.Data.Dtos.PurchaseDto;
using DairyFlow.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Business.Interfaces
{
    public interface IPurchasesProvider
    {

        PurchasesResponse GetPurchasesById(int id);
        List<PurchasesResponse> GetAllPurchases(PurchasesFilters filters);
        Task<Purchases> CreatePurchases(CreatePurchasesRequest request);
        Task<Purchases> UpdatePurchases(int id, UpdatePurchasesRequest request);
        Task<int> DeletePurchases(int id);

    }
}
