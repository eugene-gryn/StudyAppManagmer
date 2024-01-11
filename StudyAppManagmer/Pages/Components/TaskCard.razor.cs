using APIServiceLayer.Models.Tasks;

namespace StudyAppManagement.Pages.Components;

public partial class TaskCard
{
    private Task RescheduleTaskDue()
    {
        Console.WriteLine($"Reschedule task {_tempTaskChangeDueDate?.ToShortDateString()}");
        if (_tempTaskChangeDueDate != null) TaskObject.Deadline = _tempTaskChangeDueDate.Value;
        SetRescheduleTaskPopoverVisibility(false);
        return Task.CompletedTask;
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

        return Task.CompletedTask;
    }


    private Task TaskBeginCounting()
    {
        Console.WriteLine("Started counting!");
        return Task.CompletedTask;
    }

    private Task TaskDeleteOperation(int id)
    {
        Console.WriteLine($"Deleting task ID:{id}!");
        return Task.CompletedTask;
    }
}

public enum ShortView
{
    List,
    Card
}