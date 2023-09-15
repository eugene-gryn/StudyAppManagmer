using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace APIServiceLayer.Models;

public class UserRegisterDto
{
    [MaxLength(30)] public string Name { get; set; }

    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    public string Email { get; set; }
    [MaxLength(30)]
    public string Password { get; set; }
}