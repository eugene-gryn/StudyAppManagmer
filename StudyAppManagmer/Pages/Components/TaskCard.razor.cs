using APIServiceLayer.Models.Tasks;

namespace StudyAppManagement.Pages.Components;

public partial class TaskCard
{
    private Task RescheduleTaskDue()
    {
        Console.WriteLine($"Reschedule task {_tempTaskChangeDueDate?.ToShortDateString()}");
        if (_tempTaskChangeDueDate != null) TaskObject.Deadline = _tempTaskChangeDueDate.Value;
        SetRescheduleTaskPopoverVisibility(false);
        return System.Threading.Tasks.Task.CompletedTask;
    }

    private Task OnChangeSubtaskStatus(bool value, SubTaskDto subtask)
    {
        Console.WriteLine($"Changed status of subtask {subtask.Id} to {value}");

        for (var i = 0; i < TaskObject.SubTasks.Count; i++)
            if (TaskObject.SubTasks[i].Id == subtask.Id)
                TaskObject.SubTasks[i] = new SubTaskDto
                {
                    Id = TaskObject.SubTasks[i].Id,
                    Title = TaskObject.SubTasks[i].Title,
                    Status = value ? 0 : 1
                };

        return System.Threading.Tasks.Task.CompletedTask;
    }
}

public enum ShortView
{
    List,
    Card
}