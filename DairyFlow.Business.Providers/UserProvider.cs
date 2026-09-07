using DairyFlow.Business.Interfaces;
using DairyFlow.Data.Models;
using DairyFlow.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DairyFlow.Data.Dtos.UsersDto;
using DairyFlow.Infrastructure.Commons;

namespace DairyFlow.Business.Providers
{
    public class UserProvider : IUsersProvider
    {

        private readonly IRepository<Users> _userRepository;

        public UserProvider(IRepository<Users> userRepository)
        {
            _userRepository = userRepository;
        }

        public UsersResponse GetUserById(int id)
        {

            var query = (from users in _userRepository.GetAll()
                         where users.Id == id
                         select new UsersResponse
                         {
                             Id = users.Id,
                             FirstName = users.FirstName,
                             LastName = users.LastName,
                             CreatedAt = users.CreatedAt
                         });
            var usersResponse = query.FirstOrDefault();
            if (usersResponse == null)
            {
                throw new Exception($"User with ID {id} not found.");
            }
            return usersResponse;
        }

        public List<UsersResponse> GetAllUsers(UsersFilters filters)
        {
            var query =(from users in _userRepository.GetAll()
                        select new UsersResponse
                        {
                            Id = users.Id,
                            FirstName = users.FirstName,
                            LastName = users.LastName,
                            CreatedAt = users.CreatedAt
                        });
            
           if (filters.Id.HasValue)
            {
                query = query.Where(u => u.Id == filters.Id.Value);
            }
            if (!string.IsNullOrEmpty(filters.FirstName))
            {
                query = query.Where(u => u.FirstName.Contains(filters.FirstName));
            }
            if (!string.IsNullOrEmpty(filters.LastName))
            {
                query = query.Where(u => u.LastName.Contains(filters.LastName));
            }

           
            return query.GetPaginatorResult(filters.PageNumber, filters.PageSize);
        }

        public async Task<Users> CreateUser(CreateUserRequest request)
        {
            var user = new Users
                {
                FirstName = request.FirstName,
                LastName = request.LastName,
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
            return user;
        }

        public async Task<Users> UpdateUser(int id, UpdateUserRequest request)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                throw new Exception($"User with ID {id} not found.");
            }
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
            return user;
        }

        public async Task<int> DeleteUser(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                throw new Exception($"User with ID {id} not found.");
            }
            _userRepository.Delete(user);
            return await _userRepository.SaveChangesAsync();
        }

    }
}
