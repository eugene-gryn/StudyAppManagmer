using System.ComponentModel.DataAnnotations;

namespace APIServiceLayer.Models.Tasks;

public class CreateTaskDto
{
    [Required]
    [MinLength(5, ErrorMessage = "Title must be at least 5 characters!")]
    [MaxLength(30, ErrorMessage = "Title limit 30 characters!")]
    public string Title { get; set; } = string.Empty;

    [MaxLength(200, ErrorMessage = "Description limit 200 characters!")]
    public string Description { get; set; } = string.Empty;

    [Required]
    [DeadlineValidation] // Custom validation attribute for Deadline
    public DateTime? Deadline { get; set; } = DateTime.Today; 

    [Required]
    [Range(1, 5, ErrorMessage = "Priority must be between 1 and 5")]
    public int Priority { get; set; }

    public List<SubTaskDto> SubTasks { get; set; }
}

public class DeadlineValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var deadline = (DateTime)value;
        return deadline < DateTime.Today
            ? new ValidationResult("Deadline cannot be in the past")
            : ValidationResult.Success!;
    }
}