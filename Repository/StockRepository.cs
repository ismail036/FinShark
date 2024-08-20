using api.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Dtos.Stock;
using WebApplication5.Helpers;
using WebApplication5.Interfaces;

namespace WebApplication5.Repository;

public class StockRepository : IStockRepository
{

    private readonly ApplicationDbContext _context;
    public StockRepository(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }
    
    public async Task<List<Stock>> GetAllAsync(QueryObject query)
    {
        var stocks = _context.Stock.Include(c => c.Comments).ThenInclude(a => a.AppUser).AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.CompanyName))
        {
            stocks = stocks.Where(s => s.CompanyName.Contains(query.CompanyName));
        }
        
        if (!string.IsNullOrWhiteSpace(query.Sysmbol))
        {
            stocks = stocks.Where(s => s.CompanyName.Contains(query.Sysmbol));
        }
        
        if (!string.IsNullOrWhiteSpace(query.SortBy))
        {
            if (query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
            {
                stocks = query.IsDecsending ? stocks.OrderByDescending(s => s.Symbol) : stocks.OrderBy(s => s.Symbol);
            }
               
        }

        var skipNumber = (query.PageNumber - 1) * query.PageSize;
        
        return await stocks.Skip(skipNumber).Take(query.PageSize).ToListAsync();
    }

    public async Task<Stock?> GetByIdAsync(int id)
    {
        return await _context.Stock.FindAsync(id);
    }

    public async Task<Stock> CreateAsync(Stock stockModel)
    {
        await _context.Stock.AddAsync(stockModel);
        await _context.SaveChangesAsync();
        return stockModel;
    }

    public async Task<Stock?> DeleteAsync(int id)
    {
        var stockModel = await _context.Stock.Include(c=>c.Comments).FirstOrDefaultAsync(x => x.Id == id);

        if (stockModel == null)
        {
            return null;
        }

        _context.Stock.Remove(stockModel);
        
        await _context.SaveChangesAsync();
        return stockModel;  
    }
    
    public async Task<Stock?> UpdateAsync(int id, Stock stockDto)
    {
        var stockModel = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);

        if (stockModel == null)
        {
            return null;
        }
        
        stockDto.Adapt(stockModel);
        
        await _context.SaveChangesAsync();

        return stockModel;

    }
    
    public Task<bool> StockExists(int id)
    {
        return _context.Stock.AnyAsync(s => s.Id == id);
    }


    public async Task<Stock?> GetBySymbolAsync(string sysmbol)
    {
        return await _context.Stock.FirstOrDefaultAsync(s => s.Symbol == sysmbol);
    }
}