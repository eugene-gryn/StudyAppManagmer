using System.ComponentModel.DataAnnotations;

namespace APIServiceLayer.Models;

public class UserDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    public string Email { get; set; }
}