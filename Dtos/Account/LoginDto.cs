using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace WebApplication5.Dtos.Account;

public class LoginDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}


