using api.Models;

namespace WebApplication5.Interfaces;

public interface ITokenService
{
    string CreateToken(AppUser user);
}