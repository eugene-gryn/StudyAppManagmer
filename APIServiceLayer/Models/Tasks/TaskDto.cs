namespace APIServiceLayer.Models.Tasks;

public class TaskDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public int Priority { get; set; }
    public int Status { get; set; }

    public List<SubTaskDto> SubTasks { get; set; }
    
}