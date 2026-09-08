using DairyFlow.Data.Dtos.ProductsDto;
using DairyFlow.Data.Dtos.SuppliersDto;
using DairyFlow.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Business.Interfaces
{
    public interface ISuppliersProvider
    {
        SuppliersResponse GetSuppliersById(int id);
        List<SuppliersResponse> GetAllSuppliers(SuppliersFilters filters);
        Task<Suppliers> CreateSuppliers(CreateSuppliersRequest request);
        Task<Suppliers> UpdateSuppliers(int id, UpdateSuppliersRequest request);
        Task<int> DeleteSuppliers(int id);

    }
}
