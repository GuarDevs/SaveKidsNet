using AutoMapper;
using SaveKids.DAL.IRepositories;
using SaveKids.Domain.Configurations;
using SaveKids.Domain.Entities.Users;
using SaveKids.Service.DTOs.Users;
using SaveKids.Service.Exceptions;
using SaveKids.Service.Interfaces;
using System.Runtime.CompilerServices;

namespace SaveKids.Service.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IRepository<User> _repository;

    public UserService(IMapper mapper, IRepository<User> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<UserResultDto> AddAsync(UserCreationDto dto)
    {
        User newUser = _mapper.Map<User>(dto);
        if (_isUserExist(newUser))
            throw new AlreadyExistException("A user with same email or phone number is already exist.");

        newUser.DateOfBirth = dto.DateOfBirth.ToUniversalTime();
        await _repository.AddAsync(newUser);
        await _repository.SaveAsync();

        return _mapper.Map<UserResultDto>(newUser);
    }

    public async Task<UserResultDto> ModifyAsync(UserUpdateDto dto)
    {
        var theUser = _mapper.Map<User>(dto);
        
        try
        {
            _repository.Update(theUser);
        }
        catch (Exception ex)
        {
            throw new CustomException("Something went wrong. The user is not modified.", ex);
        }

        var updatedUser = await _repository.GetAsync(u => u.Id.Equals(theUser.Id));
        return _mapper.Map<UserResultDto>(theUser);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var theUser = await _repository.GetAsync(u => u.Id.Equals(id));
        if (theUser is null)
            throw new NotFoundException("Not found any user with such id.");

        _repository.Delete(theUser);
        return true;
    }

    public Task<IEnumerable<UserResultDto>> RetrieveAllAsync(PaginationParams paginationParams)
    {
        throw new NotImplementedException();
    }

    public Task<UserResultDto> RetrieveByEmailAndPassword(string email, string password)
    {
        throw new NotImplementedException();
    }

    public Task<UserResultDto> RetrieveByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    private bool _isUserExist(User user)
        => _repository.GetAll().Any(u => 
            u.Email.Equals(user.Email) || 
            u.TelNumber.Equals(user.TelNumber));
}
