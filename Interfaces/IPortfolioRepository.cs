using api.Models;

namespace WebApplication5.Interfaces;

public interface IPortfolioRepository
{
    Task<List<Stock>> GetUserPortfolio(AppUser user);

    Task<Portfolio> CreateAsync(Portfolio portfolio);

    Task<Portfolio> DeletePortfolio(AppUser appUser, string symbol);

}