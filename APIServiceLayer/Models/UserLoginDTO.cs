using System.ComponentModel.DataAnnotations;

namespace APIServiceLayer.Models;

public class UserLoginDto
{
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    [MaxLength(20, ErrorMessage = "Email length must be lower than 20 characters.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [MinLength(8, ErrorMessage = "Password length must be at least 8 characters.")]
    [MaxLength(20, ErrorMessage = "Password length must be lower than 20 characters.")]
    public string Password { get; set; }
}