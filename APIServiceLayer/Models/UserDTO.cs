using System.ComponentModel.DataAnnotations;

namespace APIServiceLayer.Models;

public class UserDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}