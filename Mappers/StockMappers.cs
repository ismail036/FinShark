using api.Models;
using WebApplication5.Dtos.Stock;
using Mapster;

namespace WebApplication5.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stock)
        { 
            return stock.Adapt<StockDto>();
        }

        public static Stock ToStockFromCreateDTO(this CreateStockRequestsDto stockDto)
        {
            return stockDto.Adapt<Stock>();
        }

        public static Stock ToStockFromUpdateDTO(this UpdateStockRequestsDto stockDto)
        {
            return stockDto.Adapt<Stock>();
        }
    }
}