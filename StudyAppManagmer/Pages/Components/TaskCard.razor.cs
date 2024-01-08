using Microsoft.AspNetCore.Components;

namespace StudyAppManagement.Pages.Components;

public partial class TaskCard
{
    private Task RescheduleTaskDue()
    {
        Console.WriteLine($"Reschedule task {_tempTaskChangeDueDate?.ToShortDateString()}");
        if (_tempTaskChangeDueDate != null) Task.Deadline = _tempTaskChangeDueDate.Value;
        SetRescheduleTaskPopoverVisibility(false);
        return System.Threading.Tasks.Task.CompletedTask;
    }
}

public enum ShortView
{
    List,
    Card
}