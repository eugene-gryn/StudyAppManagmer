using Microsoft.VisualBasic;

namespace APIServiceLayer.Models.Tasks;

public class TaskDto
{
    public int Id { get; set; } = 0;
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public int Priority { get; set; }
    public int Status { get; set; }

    public List<SubTaskDto> SubTasks { get; set; }


    public int GetPercentageOfDoneTasks()
    {
        return SubTasks.Count != 0 ?
            (int)((double)SubTasks.Count(st => st.Status == 0) / SubTasks.Count * 100) : 100;
    }

    public string StatusStringView()
    {
        // TODO: Connect to api documentation
        return Status switch
        {
            0 => "Done",
            1 => "In work",
            2 => "Preparing to work",
            _ => "Unknown status!"
        };
    }

    public string PriorityStringView()
    {
        return Priority switch
        {
            1 => "Critical",
            2 => "Critical",
            3 => "Normal",
            4 => "Low",
            5 => "Low",
            _ => "Unknown priority!"
        };
    }

    public string GetDeadlineInStringView()
    {
        if (Deadline.Date == DateTime.Today) return "Today";
        if (Deadline.Date == DateTime.Today.AddDays(1)) return "Tomorrow";

        if (Deadline.Date < DateTime.Today) return "Overdue" + Deadline.ToString("dd/MM");

        return Deadline.ToString("dd MMM");
    }
}