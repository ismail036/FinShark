using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Dtos.Stock;

public class UpdateStockRequestsDto
{
    
    [Required]
    [MaxLength(10,ErrorMessage = "Symbol cannot be over 10 character")]
    public string Symbol { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(10,ErrorMessage = "Company name cannot be over 10 character")] 
    public string CompanyName { get; set; } = string.Empty;
    
    [Required]
    [Range(1,1000000000)]
    public decimal Purchase { get; set; }
    
    [Required]
    [Range(0.001,100)]
    public decimal LastDiv { get; set; }
    
    [Required]
    [MaxLength(20, ErrorMessage = "Industry cannot be over 20 character")]
    public string Industry { get; set; } = string.Empty;
    
    [Required]
    [Range(1,5000000000000000)]
    public long MarketCap { get; set; }
}