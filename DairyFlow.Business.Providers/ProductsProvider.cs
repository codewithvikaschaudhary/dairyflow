using DairyFlow.Business.Interfaces;
using DairyFlow.Data.Dtos.ProductsDto;
using DairyFlow.Data.Models;
using DairyFlow.Data.Repository;
using DairyFlow.Infrastructure.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Business.Providers
{
    public class ProductsProvider : IProductsProvider
    {

        private readonly IRepository<Products> _productsRepository;
        private readonly IRepository<Categories> _categoriesRepository;
        private readonly IRepository<Brands> _brandsRepository;
        private readonly IRepository<Users> _usersRepository;
        public ProductsProvider(IRepository<Products> productsRepository, IRepository<Categories> categoriesRepository, IRepository<Brands> brandsRepository, IRepository<Users> usersRepository)
        {
            _productsRepository = productsRepository;
            _categoriesRepository = categoriesRepository;
            _brandsRepository = brandsRepository;
            _usersRepository = usersRepository;
        }
        public ProductsResponse GetProductsById(int id)
        {
            var query = (from product in _productsRepository.GetAll()
                         join category in _categoriesRepository.GetAll() on product.CategoryId equals category.Id
                         join brand in _brandsRepository.GetAll() on product.BrandId equals brand.Id
                         join createdUser in _usersRepository.GetAll() on product.CreatedBy equals createdUser.Id
                         join modifiedUser in _usersRepository.GetAll() on product.ModifiedBy equals modifiedUser.Id
                         where product.Id == id
                         select new ProductsResponse
                         {
                             Id = product.Id,
                             Name = product.Name,
                             CategoryId = product.CategoryId,
                             CategoryName = category.Name,
                             BrandId = product.BrandId,
                             BrandName = brand.Name,
                             CreatedBy = $"{createdUser.FirstName} {createdUser.LastName}",
                             ModifiedBy = $"{modifiedUser.FirstName} {modifiedUser.LastName}",
                         });

            var products = query.FirstOrDefault();

            if (products == null)
            {
                throw new Exception($"Products with ID {id} not found.");
            }
            return products;
        }
        public List<ProductsResponse> GetAllProducts(ProductsFilters filters)
        {
            var query = (from product in _productsRepository.GetAll()
                         join category in _categoriesRepository.GetAll() on product.CategoryId equals category.Id
                         join brand in _brandsRepository.GetAll() on product.BrandId equals brand.Id
                         join createdUser in _usersRepository.GetAll() on product.CreatedBy equals createdUser.Id
                         join modifiedUser in _usersRepository.GetAll() on product.ModifiedBy equals modifiedUser.Id
                         select new ProductsResponse
                         {
                             Id = product.Id,
                             Name = product.Name,
                             CategoryId = product.CategoryId,
                             CategoryName = category.Name,
                             BrandId = product.BrandId,
                             BrandName = brand.Name,
                             CreatedBy = $"{createdUser.FirstName} {createdUser.LastName}",
                             CreatedByFirstName = createdUser.FirstName,
                             CreatedByLastName = createdUser.LastName,
                             ModifiedBy = $"{modifiedUser.FirstName} {modifiedUser.LastName}",
                             ModifiedByFirstName = modifiedUser.FirstName,
                             ModifiedByLastName = modifiedUser.LastName,
                         });

            if (filters.Id.HasValue)
            {
                query = query.Where(p => p.Id == filters.Id.Value);
            }
            if (!string.IsNullOrEmpty(filters.Name))
            {
                query = query.Where(p => p.Name.Contains(filters.Name));
            }
            if (!string.IsNullOrEmpty(filters.CategoryName))
            {
                query = query.Where(p => p.CategoryName.Contains(filters.CategoryName));
            }
            if (!string.IsNullOrEmpty(filters.BrandName))
            {
                query = query.Where(p => p.BrandName.Contains(filters.BrandName));
            }
            if (!string.IsNullOrEmpty(filters.CreatedBy))
            {
                query = query.Where(p => p.CreatedByFirstName!.Contains(filters.CreatedBy) || (p.CreatedByLastName != null && p.CreatedByLastName!.Contains(filters.CreatedBy)));
            }
            if (!string.IsNullOrEmpty(filters.ModifiedBy))
            {
                query = query.Where(p => p.ModifiedByFirstName!.Contains(filters.ModifiedBy) || (p.ModifiedByLastName != null && p.ModifiedByLastName!.Contains(filters.ModifiedBy)));
            }

                return query.GetPaginatorResult(filters.PageNumber, filters.PageSize);
        }
        public async Task<Products> CreateProducts(CreateProductsRequest request)
        {
            var products = new Products
            {
                Name = request.Name,
                CategoryId = request.CategoryId,
                BrandId = request.BrandId,
                CreatedBy = request.CreatedBy,
                ModifiedBy = request.ModifiedBy,
            };
            await _productsRepository.AddAsync(products);
            await _productsRepository.SaveChangesAsync();
            return products;
        }
        public async Task<Products> UpdateProducts(int id, UpdateProductsRequest request)
        {
            var products = _productsRepository.GetById(id);
            if (products == null)
            {
                throw new Exception($"Products with ID {id} not found.");
            }
            products.Name = request.Name;
            products.CategoryId = request.CategoryId;
            products.BrandId = request.BrandId;
            products.CreatedBy = request.CreatedBy;
            products.ModifiedBy = request.ModifiedBy;
            _productsRepository.Update(products);
            await _productsRepository.SaveChangesAsync();
            return products;
        }
        public async Task<int> DeleteProducts(int id)
        {
            var products = _productsRepository.GetById(id);
            if (products == null)
            {
                throw new Exception($"Products with ID {id} not found.");
            }
            _productsRepository.Delete(products);
            await _productsRepository.SaveChangesAsync();
            return id;
        }   


    }
}
