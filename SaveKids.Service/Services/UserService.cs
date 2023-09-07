using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaveKids.DAL.IRepositories;
using SaveKids.Domain.Configurations;
using SaveKids.Domain.Entities.Users;
using SaveKids.Domain.Enums;
using SaveKids.Service.DTOs.Users;
using SaveKids.Service.Exceptions;
using SaveKids.Service.Extensions;
using SaveKids.Service.Interfaces;

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
        if (this.DoesUserExist(newUser))
            throw new AlreadyExistException("A user with same email or phone number already exists.");

        newUser.Role = UserRole.User;
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
            throw new CustomException("Something went wrong. Look at inner exception.", ex);
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

    public async Task<bool> DestroyAsync(long id)
    {
        var theUser = await _repository.GetAsync(u => u.Id.Equals(id));
        if (theUser is null)
            throw new NotFoundException("Not found any user with such id.");

        _repository.Destroy(theUser);
        return true;
    }

    public async Task<IEnumerable<UserResultDto>> RetrieveAllAsync(PaginationParams paginationParams)
    {
        // Paginating --->>
        var users = await _repository.GetAll()
                    .ToPaginate(paginationParams)
                    .ToListAsync();
        
        // Mapping --->>
        var result = _mapper.Map<IEnumerable<UserResultDto>>(users);
        
        return result;
    }

    public async Task<UserResultDto> RetrieveByEmailAndPasswordAsync(string email, string password)
    {
        var theUser = await _repository.GetAsync(u => 
                           u.Email.Equals(email) &&
                           u.Password.Equals(password));

        if (theUser is null)
            throw new NotFoundException("Email or password is incorrect.");

        return _mapper.Map<UserResultDto>(theUser);
    }

    public async Task<UserResultDto> RetrieveByIdAsync(long id)
    {
        var theUser = await _repository.GetAsync(u => u.Id.Equals(id));

        if (theUser is null)
            throw new NotFoundException("Not found any user with such id.");

        return _mapper.Map<UserResultDto>(theUser);
    }

    private bool DoesUserExist(User user)
        => _repository.GetAll().Any(u => 
            u.Email.Equals(user.Email) || 
            u.TelNumber.Equals(user.TelNumber));
}
