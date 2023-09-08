using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SaveKids.DAL.IRepositories;
using SaveKids.Domain.Configurations;
using SaveKids.Domain.Entities.Users;
using SaveKids.Domain.Enums;
using SaveKids.Service.DTOs.Users;
using SaveKids.Service.Exceptions;
using SaveKids.Service.Extensions;
using SaveKids.Service.Helpers;
using SaveKids.Service.Interfaces;
using System.Xml.Linq;

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
        var existTelNmber = TelNumberChecker.IsUzbNumber(dto.TelNumber);
        if (existTelNmber == false)
            throw new CustomException($"This tel number is valid {dto.TelNumber}");

        User newUser = _mapper.Map<User>(dto);
        if (this.DoesUserExist(newUser))
            throw new AlreadyExistException("A user with same email or phone number already exists.");

        newUser.Role = UserRole.User;
        newUser.DateOfBirth = dto.DateOfBirth.ToUniversalTime();

        newUser.Password = PasswordHash.Encrypt(dto.Password);
        await _repository.AddAsync(newUser);
        await _repository.SaveAsync();

        return _mapper.Map<UserResultDto>(newUser);
    }

    public async Task<UserResultDto> ModifyAsync(UserUpdateDto dto)
    {
        var existTelNmber = TelNumberChecker.IsUzbNumber(dto.TelNumber);
        if (existTelNmber == false)
            throw new CustomException($"This tel number is valid {dto.TelNumber}");

        var existUser = await _repository.GetAsync(u => u.Id.Equals(dto.Id))
            ?? throw new NotFoundException($"This user was not found with {dto.Id}");

        if(!(existUser.Email.ToLower().Equals(dto.Email.ToLower())
            || existUser.TelNumber.Equals(dto.TelNumber)))
        {
            User newUser = _mapper.Map<User>(dto);
            if (this.DoesUserExist(newUser))
                throw new AlreadyExistException("A user with same email or phone number already exists.");
        }

        _mapper.Map(dto, existUser);
        existUser.Password = PasswordHash.Encrypt(dto.Password);
        _repository.Update(existUser);
        await _repository.SaveAsync();

        return _mapper.Map<UserResultDto>(existUser);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var theUser = await _repository.GetAsync(u => u.Id.Equals(id));
        if (theUser is null)
            throw new NotFoundException("Not found any user with such id.");

        _repository.Delete(theUser);
        await _repository.SaveAsync();

        return true;
    }

    public async Task<bool> DestroyAsync(long id)
    {
        var theUser = await _repository.GetAsync(u => u.Id.Equals(id));
        if (theUser is null)
            throw new NotFoundException("Not found any user with such id.");

        _repository.Destroy(theUser);
        await _repository.SaveAsync();

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
                           u.Email.ToLower().Equals(email.ToLower()));
        if (theUser is null)
            throw new NotFoundException("Email is not found");

        var isValid = PasswordHash.Verify(theUser.Password, password);
        if(!isValid)
            throw new CustomException("Password or telnumber is incorrect.");

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
            u.Email.ToLower().Equals(user.Email.ToLower()) || 
            u.TelNumber.Equals(user.TelNumber));

    public async Task<UserResultDto> UpgradeUserRoleAsync(long userId, UserRole role)
    {
        var user = await _repository.GetAsync(u => u.Id.Equals(userId));
        if (user is null)
            throw new NotFoundException("Not found any user with such id.");

        user.Role = role;
        await _repository.SaveAsync();

        return _mapper.Map<UserResultDto>(user);
    }

    public async Task<IEnumerable<UserResultDto>> SearchByNameAsync(string name, PaginationParams paginationParams)
    {
        var users = _repository.GetAll(u=> u.FirstName.Contains(name),true,null);

        return _mapper.Map<IEnumerable<UserResultDto>>(users);
    }

}
