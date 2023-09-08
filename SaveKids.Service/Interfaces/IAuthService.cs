namespace SaveKids.Service.Interfaces;

public interface IAuthService
{
    Task<string> GenerateTokenAsync(string telNumber, string password);
}
