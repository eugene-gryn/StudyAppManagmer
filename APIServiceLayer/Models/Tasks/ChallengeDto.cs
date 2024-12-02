using System.ComponentModel.DataAnnotations;
using APIServiceLayer.Models.Tasks.Enums;

namespace APIServiceLayer.Models.Tasks;

public class ChallengeDto
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50, ErrorMessage = "Title max length is 50!")]
    public string Title { get; set; }

    [Required]
    [MaxLength(1000, ErrorMessage = "Maximum length is 1000 chars!")]
    public string Description { get; set; }

    public DateTime Deadline { get; set; }
    [Required] public ChallengePriority Priority { get; set; }
    public ChallengeStatus Status { get; set; } = ChallengeStatus.NotStarted;

    public List<SubTaskDto> SubTasks { get; set; } = new();


    public int GetPercentageOfDoneTasks()
    {
        return SubTasks.Count != 0 ? (int)((double)SubTasks.Count(st => st.Status == 0) / SubTasks.Count * 100) : 100;
    }

    public static string StatusStringView(ChallengeStatus status)
    {
        return status switch
        {
            ChallengeStatus.NotStarted => "Not Started",
            ChallengeStatus.InProcess => "In Process",
            ChallengeStatus.Completed => "Completed",
            ChallengeStatus.OnHold => "OnHold",
            ChallengeStatus.Cancelled => "Cancelled",
            _ => "Unknown status!"
        };
    }

    public static string PriorityStringView(ChallengePriority priority)
    {


        return priority switch
        {
            ChallengePriority.Lowest => "Lowest",
            ChallengePriority.Low => "Low",
            ChallengePriority.Medium => "Medium",
            ChallengePriority.High => "High",
            ChallengePriority.Highest => "Highest",
            _ => "Unknown priority!"
        };
    }

    public static string GetDeadlineInStringView(DateTime deadline)
    {
        if (deadline.Date == DateTime.Today) return "Today";
        if (deadline.Date == DateTime.Today.AddDays(1)) return "Tomorrow";

        if (deadline.Date < DateTime.Today) return "Overdue" + deadline.ToString("dd/MM");

        return deadline.ToString("dd MMM");
    }

    public static bool GetBoolStatus(int status)
    {
        return status == 0;
    }
}