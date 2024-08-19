using Microsoft.AspNetCore.Mvc;
using WebApplication5.Data;
using WebApplication5.Dtos.Stock;
using WebApplication5.Mappers;
using api.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Helpers;
using WebApplication5.Interfaces;

namespace WebApplication5.Controllers;

[Route("api/stock")]
[ApiController]
public class StockController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IStockRepository _stockRepo;
    
    public StockController(ApplicationDbContext context , IStockRepository stockRepository)
    {
        _stockRepo = stockRepository;
        _context   = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
    {
        var stocks  = await _stockRepo.GetAllAsync(query);
        return Ok(stocks);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var stock = await _stockRepo.GetByIdAsync(id);

        if (stock == null)
        {
            return NotFound();
        }

        var stockDto = StockMappers.ToStockDto(stock);

        return Ok(stockDto);
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStockRequestsDto stockDto) 
    {
        var stockModel = StockMappers.ToStockFromCreateDTO(stockDto);
        await _stockRepo.CreateAsync(stockModel);
        return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel);
    }
    
    
    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestsDto updateDto)
    {
        var stockModel = await _stockRepo.GetByIdAsync(id);

        if (stockModel == null)
        {
            return NotFound();
        }
        updateDto.Adapt(stockModel);

        var updatedStock = await _stockRepo.UpdateAsync(id, stockModel);

        return Ok(updatedStock.Adapt<StockDto>());
    }


    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var stockModel = await _stockRepo.DeleteAsync(id);

        if (stockModel == null) 
        {
            return NotFound();
        }
        
        return NoContent();
    }
}