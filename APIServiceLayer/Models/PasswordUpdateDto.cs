using System.ComponentModel.DataAnnotations;

namespace APIServiceLayer.Models;

public class PasswordUpdateDto
{
    [Required]
    [MaxLength(15, ErrorMessage = "Max length is 15 for password")]
    [MinLength(6, ErrorMessage = "Min length is 6 for password")]
    public string Password { get; set; }

    [Required]
    [Compare(nameof(Password), ErrorMessage = "Passwords didn't match")]
    public string Password2 { get; set; }

}