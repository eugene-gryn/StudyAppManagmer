using System.ComponentModel.DataAnnotations;

namespace APIServiceLayer.Models;

public class UserLoginDTO
{
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    public string Email { get; set; }
    public string Password { get; set; }
}