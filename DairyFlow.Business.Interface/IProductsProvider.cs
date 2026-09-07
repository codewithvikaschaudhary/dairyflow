using DairyFlow.Data.Dtos.BrandsDto;
using DairyFlow.Data.Dtos.ProductsDto;
using DairyFlow.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Business.Interfaces
{
    public interface IProductsProvider
    {

        ProductsResponse GetProductsById(int id);
        List<ProductsResponse> GetAllProducts(ProductsFilters filters);
        Task<Products> CreateProducts(CreateProductsRequest request);
        Task<Products> UpdateProducts(int id, UpdateProductsRequest request);
        Task<int> DeleteProducts(int id);

    }
}
