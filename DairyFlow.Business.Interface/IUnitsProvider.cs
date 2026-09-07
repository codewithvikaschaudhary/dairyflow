using DairyFlow.Data.Dtos.UnitsDto;
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
        Task<UnitsResponse> GetUnits(UnitsFilters filters);
        Task<UnitsResponse> CreateUnits(CreateUnitsRequest request);
        Task<UnitsResponse> UpdateUnits(int id, UpdateUnitsRequest request);
        Task<int> DeleteUnit(int id);

    }
}
