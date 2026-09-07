using DairyFlow.Data.Dtos.CategoriesDto;
using DairyFlow.Data.Dtos.UsersDto;
using DairyFlow.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Business.Interfaces
{
    public interface ICategoriesProvider
    {

        CategoriesResponse GetCategoriesById(int id);
        List<CategoriesResponse> GetAllCategories(CategoriesFilters filters);
        Task<Categories> CreateCategories(CreateCategoriesRequest request);
        Task<Categories> UpdateCategories(int id, UpdateCategoriesRequest request);
        Task<int> DeleteCategories(int id);

    }
}
