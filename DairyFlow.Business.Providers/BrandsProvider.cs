using DairyFlow.Business.Interfaces;
using DairyFlow.Data.Dtos.BrandsDto;
using DairyFlow.Data.Models;
using DairyFlow.Data.Repository;
using DairyFlow.Infrastructure.Commons;

namespace DairyFlow.Business.Providers
{
    public class BrandsProvider : IBrandsProvider
    {

        private readonly IRepository<Brands> _brandsRepository;
        private readonly IRepository<Users> _usersRepository;

        public BrandsProvider(IRepository<Brands> brandsRepository, IRepository<Users> usersRepository)
        {
            _brandsRepository = brandsRepository;
            _usersRepository = usersRepository;
        }

        public BrandsResponse GetBrandsById(int id)
        {
            var query = (from brand in _brandsRepository.GetAll()
                         join createdUser in _usersRepository.GetAll() on brand.CreatedBy equals createdUser.Id
                         join modifiedUser in _usersRepository.GetAll() on brand.ModifiedBy equals modifiedUser.Id
                         where brand.Id == id
                         select new BrandsResponse
                         {
                             Id = brand.Id,
                             Name = brand.Name,
                             CreatedBy = $"{createdUser.FirstName} {createdUser.LastName}",
                             ModifiedBy = $"{modifiedUser.FirstName} {modifiedUser.LastName}",
                         });
            var brands = query.FirstOrDefault();
            if (brands == null)
            {
                throw new Exception($"Brands with ID {id} not found.");
            }
            return brands;
        }

        public List<BrandsResponse> GetAllBrands(BrandsFilters filters)
        {
            var query = (from brand in _brandsRepository.GetAll()
                         join createdUser in _usersRepository.GetAll() on brand.CreatedBy equals createdUser.Id
                         join modifiedUser in _usersRepository.GetAll() on brand.ModifiedBy equals modifiedUser.Id
                         select new BrandsResponse
                         {
                             Id = brand.Id,
                             Name = brand.Name,
                             CreatedBy = $"{createdUser.FirstName}{createdUser.LastName}",
                             ModifiedBy = $"{modifiedUser.FirstName}{modifiedUser.LastName}",
                         });

            if (filters.Id.HasValue)
            {
                query = query.Where(i => i.Id == filters.Id.Value);
            }
            if (!string.IsNullOrEmpty(filters.Name))
            {
                query = query.Where(i => i.Name.Contains(filters.Name));
            }
            if (!string.IsNullOrEmpty(filters.CreatedBy))
            {
                query = query.Where(i => i.CreatedBy.Contains(filters.CreatedBy));
            }
            if (!string.IsNullOrEmpty(filters.ModifiedBy))
            {
                query = query.Where(i => i.ModifiedBy.Contains(filters.ModifiedBy));
            }

            return query.GetPaginatorResult(filters.PageNumber, filters.PageSize);
        }

        public async Task<Brands> CreateBrands(CreateBrandsRequest request)
        {
            var brands = new Brands
            {
                Name = request.Name,
                CreatedBy = request.CreatedBy,
                ModifiedBy = request.ModifiedBy,
            };
            await _brandsRepository.AddAsync(brands);
            await _brandsRepository.SaveChangesAsync();
            return brands;
        }

        public async Task<Brands> UpdateBrands(int id, UpdateBrandsRequest request)
        {
            var brands = _brandsRepository.GetById(id);
            if (brands == null)
            {
                throw new Exception($"Brands with ID {id} not found.");
            }
            brands.Name = request.Name;
            brands.CreatedBy = request.CreatedBy;
            brands.ModifiedBy = request.ModifiedBy;
            _brandsRepository.Update(brands);
            await _brandsRepository.SaveChangesAsync();
            return brands;
        }

        public async Task<int> DeleteBrands(int id)
        {
            var brands = _brandsRepository.GetById(id);
            if (brands == null)
            {
                throw new Exception($"Brands with ID {id} not found.");
            }
            _brandsRepository.Delete(brands);
            await _brandsRepository.SaveChangesAsync();
            return id;
        }

    }
}
