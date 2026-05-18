using System;
using StoreBackend.Domain.Entities;
using StoreBackend.Dto;
using StoreBackend.Exceptions;
using StoreBackend.Infrastructure.Repositories;

namespace StoreBackend.DomainService;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<List<User>> GetAllAsync()
    {
        return _userRepository.GetAllAsync();
    }

    public Task<User?> GetByResourceIdAsync(Guid id)
    {
        return _userRepository.GetByIdAsync(id);
    }

    public async Task<User> CreateAsync(CreateUserDto user)
    {
        if (await _userRepository.HasUserByUsernameAsync(user.Username))
        {
            throw new Exceptions.BadRequestResponseException("Username is already taken");
        }
        if (await _userRepository.HasUserByEmailAsync(user.Email))
        {
            throw new Exceptions.BadRequestResponseException("Email is already taken");
        }

        var entity = new User
        {
            UserResourceId = Guid.NewGuid(),
            Name = user.Name,
            Username = user.Username,
            Email = user.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password),
        };

        return await _userRepository.CreateAsync(entity);
    }

    public async Task<User?> GetByUserAndPassword(AuthorizationRequestDto request)
    {
        var user = await _userRepository.GetByUsername(request.Username);
        if (user == null)
        {
            return null;
        }

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            return null;
        }

        return user;
    }
}