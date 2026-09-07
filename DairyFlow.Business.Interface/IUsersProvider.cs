using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DairyFlow.Data.Dtos.UsersDto;
using DairyFlow.Data.Models;

namespace DairyFlow.Business.Interfaces
{
    public interface IUsersProvider
    {
        UsersResponse GetUserById(int id);
        List<UsersResponse> GetAllUsers(UsersFilters filters);
        Task<Users> CreateUser(CreateUserRequest request);
        Task<Users> UpdateUser(int id, UpdateUserRequest request);
        Task<int> DeleteUser(int id);


    }
}
