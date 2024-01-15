using System.ComponentModel.DataAnnotations;

namespace APIServiceLayer.Models.Tasks;

public class SubTaskDto
{
    private const int PreparingCodeStatus = 2;

    public int Id { get; init; } = 0;

    [Required]
    [MinLength(5, ErrorMessage = "Title must be at least 5 characters!")]
    [MaxLength(30, ErrorMessage = "Title limit 30 characters!")]
    public string Title { get; set; } = string.Empty;

    [Required] public int Status { get; set; } = PreparingCodeStatus;
}