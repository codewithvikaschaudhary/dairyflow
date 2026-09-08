using DairyFlow.Data.Dtos.UnitsDto;
using DairyFlow.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Business.Interfaces
{
    public interface IUnitsProvider
    {
        UnitsResponse GetUnitsById(int id);
        List<UnitsResponse> GetAllUnits(UnitsFilters filters);
        Task<Units> CreateUnits(CreateUnitsRequest request);
        Task<Units> UpdateUnits(int id, UpdateUnitsRequest request);
        Task<int> DeleteUnits(int id);

    }
}
