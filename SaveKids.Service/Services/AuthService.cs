using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SaveKids.DAL.IRepositories;
using SaveKids.Domain.Entities.Users;
using SaveKids.Service.Exceptions;
using SaveKids.Service.Helpers;
using SaveKids.Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SaveKids.Service.Services;

public class AuthService : IAuthService
{
    private readonly IRepository<User> _userRepository;
    private readonly IConfiguration _configuration;

    public AuthService(IRepository<User> userRepository, IConfiguration configuration)
    {
        _configuration = configuration;
        _userRepository = userRepository;
    }

    public async Task<string> GenerateTokenAsync(string telNumber, string password)
    {
        var user = await _userRepository.GetAsync(u => u.TelNumber.Equals(telNumber))
            ?? throw new NotFoundException($"This user not found with {telNumber}");

        bool isValid = PasswordHash.Verify(user.Password, password);
        if (!isValid)
            throw new CustomException("This password or telnumber invalid");

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
          {
             new Claim("TelNumber", user.TelNumber),
             new Claim("Id", user.Id.ToString()),
             new Claim(ClaimTypes.Role, user.Role.ToString()),
          }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        var result = tokenHandler.WriteToken(token);

        return result;
    }
}
