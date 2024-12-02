using APIServiceLayer.Models.Tasks;
using APIServiceLayer.Models.Tasks.Enums;

namespace StudyAppManagement.Pages;

public partial class Index
{
    private readonly List<ChallengeDto> _tasks = new()
    {
        new ChallengeDto
        {
            Title = "Make some project#1",
            Description =
                "Some project that makes someones life easy. This is default long description for similar tasks, that makes easy someones life.",
            Deadline = DateTime.Now.AddHours(100),
            Priority = (ChallengePriority)1,
            Status = (ChallengeStatus)2,
            SubTasks = new List<SubTaskDto>
            {
                new()
                {
                    Id = 0,
                    Title = "Some little subtask#1",
                    Status = 1
                },
                new()
                {
                    Id = 1,
                    Title = "Some little subtask#2",
                    Status = 1
                },
                new()
                {
                    Id = 2,
                    Title = "Some little subtask#3",
                    Status = 1
                },
                new()
                {
                    Id = 3,
                    Title = "Some little subtask#4",
                    Status = 1
                }
            }
        },
        new ChallengeDto
        {
            Title = "Make some project#2",
            Description =
                "Some project that makes someones life easy. This is default long description for similar tasks, that makes easy someones life.",
            Deadline = DateTime.Now.AddHours(12),
            Priority = (ChallengePriority) 3,
            Status = (ChallengeStatus)1,
            SubTasks = new List<SubTaskDto>
            {
                new()
                {
                    Title = "Some little subtask#1",
                    Status = 1
                },
                new()
                {
                    Title = "Some little subtask#2",
                    Status = 0
                },
                new()
                {
                    Title = "Some little subtask#3",
                    Status = 1
                }
            }
        },
        new ChallengeDto
        {
            Title = "Make some project#3",
            Description =
                "Some project that makes someones life easy. This is default long description for similar tasks, that makes easy someones life.",
            Deadline = DateTime.Now.AddHours(13),
            Priority = (ChallengePriority) 5,
            Status = 0,
            SubTasks = new List<SubTaskDto>
            {
                new()
                {
                    Title = "Some little subtask#1",
                    Status = 0
                },
                new()
                {
                    Title = "Some little subtask#2",
                    Status = 0
                },
                new()
                {
                    Title = "Some little subtask#3",
                    Status = 0
                }
            }
        },
        new ChallengeDto
        {
            Title = "Make some project#4",
            Description =
                "Some project that makes someones life easy. This is default long description for similar tasks, that makes easy someones life.",
            Deadline = DateTime.Now.AddHours(14),
            Priority = (ChallengePriority) 3,
            Status = (ChallengeStatus) 1,
            SubTasks = new List<SubTaskDto>
            {
                new()
                {
                    Title = "Some little subtask#1",
                    Status = 1
                },
                new()
                {
                    Title = "Some little subtask#2",
                    Status = 0
                },
                new()
                {
                    Title = "Some little subtask#3",
                    Status = 1
                }
            }
        },
        new ChallengeDto
        {
            Title = "Make some project#5",
            Description =
                "Some project that makes someones life easy. This is default long description for similar tasks, that makes easy someones life.",
            Deadline = DateTime.Now.AddHours(15),
            Priority = (ChallengePriority) 3,
            Status = (ChallengeStatus) 1,
            SubTasks = new List<SubTaskDto>
            {
                new()
                {
                    Title = "Some little subtask#1",
                    Status = 1
                },
                new()
                {
                    Title = "Some little subtask#2",
                    Status = 1
                },
                new()
                {
                    Title = "Some little subtask#3",
                    Status = 1
                }
            }
        },
        new ChallengeDto
        {
            Title = "Make some project#6",
            Description =
                "Some project that makes someones life easy. This is default long description for similar tasks, that makes easy someones life.",
            Deadline = DateTime.Now.AddHours(16),
            Priority = (ChallengePriority)3,
            Status = (ChallengeStatus)1,
            SubTasks = new List<SubTaskDto>
            {
                new()
                {
                    Title = "Some little subtask#1",
                    Status = 1
                },
                new()
                {
                    Title = "Some little subtask#2",
                    Status = 1
                },
                new()
                {
                    Title = "Some little subtask#3",
                    Status = 1
                }
            }
        }
    };


    private Task OnCreationNewTask(CreateTaskDto task)
    {
        Console.WriteLine($"Created new task {task.Title} - {task.Deadline?.ToShortDateString()}");
        if (task.Deadline != null)
            _tasks.Add(new ChallengeDto
            {
                Title = task.Title,
                Description = task.Description,
                Priority = (ChallengePriority)task.Priority,
                Deadline = task.Deadline.Value,
                Status = (ChallengeStatus)2
            });
        return Task.CompletedTask;
    }
}