using DairyFlow.Data.Dtos.InventoriesDto;
using DairyFlow.Data.Dtos.UsersDto;
using DairyFlow.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFlow.Business.Interfaces
{
    public interface IInventoriesProvider
    {

        InventoriesResponse GetInventoriesById(int id);
        List<InventoriesResponse> GetAllInventories(InventoriesFilters filters);
        Task<Inventories> CreateInventories(CreateInventoriesRequest request);
        Task<Inventories> UpdateInventories(int id, UpdateInventoriesRequest request);
        Task<int> DeleteInventories(int id);


    }
}

