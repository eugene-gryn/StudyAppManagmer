using System.ComponentModel.DataAnnotations;

namespace APIServiceLayer.Models;

public class UserRegisterDto
{
    [Required] 
    [MaxLength(10, ErrorMessage = "Max length is 10 for name")] 
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(20, ErrorMessage = "Max length is 20 for name")]
    public string Email { get; set; }

    [Required] 
    [MaxLength(20, ErrorMessage = "Max length is 20 for password")] 
    [MinLength(8, ErrorMessage = "Min length is 8 for password")] 
    public string Password { get; set; }

    [Required]
    [Compare(nameof(Password), ErrorMessage = "Passwords didn't match")]
    public string Password2 { get; set; }
}