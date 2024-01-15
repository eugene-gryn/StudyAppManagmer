namespace APIServiceLayer.Models.Tasks;

public class TaskDto
{
    public int Id { get; set; } = 0;
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public int Priority { get; set; }
    public int Status { get; set; }

    public List<SubTaskDto> SubTasks { get; set; } = new List<SubTaskDto>();


    public int GetPercentageOfDoneTasks()
    {
        return SubTasks.Count != 0 ? (int)((double)SubTasks.Count(st => st.Status == 0) / SubTasks.Count * 100) : 100;
    }

    public static string StatusStringView(int status)
    {
        // TODO: Connect to api documentation
        return status switch
        {
            0 => "Done",
            1 => "In work",
            2 => "Preparing to work",
            _ => "Unknown status!"
        };
    }

    public static string PriorityStringView(int priority)
    {
        return priority switch
        {
            1 => "Critical",
            2 => "Critical",
            3 => "Normal",
            4 => "Low",
            5 => "Low",
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