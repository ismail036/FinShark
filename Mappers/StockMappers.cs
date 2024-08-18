using WebApplication5.Dtos.Stock;
using api.Models; 
using WebApplication5.Dtos.Comments;

namespace WebApplication5.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap,
                Comment = stockModel.Comments
                    .Select(c => new CommentDto
                    {
                        Id = c.Id,
                        Title = c.Title,
                        Content = c.Content,
                        CreatedOn = c.CreatedOn,
                        StockId = c.StockId
                    })
                    .ToList(),                
            };
        }
        
            
        public static Stock ToStockFromCreateDTO(CreateStockRequestsDto stockDto)
        {
            return new Stock
            {
                Symbol = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                Purchase = stockDto.Purchase,
                LastDiv = stockDto.LastDiv,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MarketCap
            };
        }
        
    }
}