using System;
using StoreBackend.Domain.Entities;
using StoreBackend.Dto;

namespace StoreBackend.DomainService;

public interface IUserService
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByResourceIdAsync(Guid id);
    Task<User> CreateAsync(CreateUserDto user);
    Task<User?> GetByUserAndPassword(AuthorizationRequestDto request);

}