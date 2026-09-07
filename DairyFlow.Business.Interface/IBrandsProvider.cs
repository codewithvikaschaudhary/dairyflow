using DairyFlow.Data.Dtos.BrandsDto;
using DairyFlow.Data.Dtos.CategoriesDto;
using DairyFlow.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Business.Interfaces
{
    public interface IBrandsProvider
    {

        BrandsResponse GetBrandsById(int id);
        List<BrandsResponse> GetAllBrands(BrandsFilters filters);
        Task<Brands> CreateBrands(CreateBrandsRequest request);
        Task<Brands> UpdateBrands(int id, UpdateBrandsRequest request);
        Task<int> DeleteBrands(int id);

    }
}
