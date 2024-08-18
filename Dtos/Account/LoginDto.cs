using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Dtos.Account;

public class LoginDto
{
    
    [Required]
    public string Username { get; set; }
    
    [Required]
    public string Password { get; set; }
    
}