using api.Models;
using WebApplication5.Dtos.Stock;
using WebApplication5.Helpers;

namespace WebApplication5.Interfaces;

public interface IStockRepository
{
    Task<List<Stock>> GetAllAsync(QueryObject query);
    Task<Stock?> GetByIdAsync(int id);
    Task<Stock> CreateAsync(Stock stockModel);
    Task<Stock?> UpdateAsync(int id, Stock stockModel);
    Task<Stock?> DeleteAsync(int id);

    Task<bool> StockExists(int id);
}