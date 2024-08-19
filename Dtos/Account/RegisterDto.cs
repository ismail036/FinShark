using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Dtos.Account;

public class RegisterDto
{
    public string?  Username { get; set; }

    [EmailAddress]
    public string?  Email { get; set; }
    
    public string?  Password { get; set; }
    
}