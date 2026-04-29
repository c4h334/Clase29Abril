using System;
using StoreBackend.Domain.Entities;
using StoreBackend.Dto;

using StoreBackend.Domain.Entities;

namespace StoreBackend.DomainService
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> CreateAsync(CreateUserDto user);
    }
}
