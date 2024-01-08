namespace APIServiceLayer.Models.Tasks;

public class SubTaskDto
{
    public int Id { get; init; } = 0;
    public string Title { get; init; }
    public int Status { get; init; }

    public bool GetBoolStatus()
    {
        return Status switch
        {
            0 => true,
            1 => false,
            2 => false,
            _ => false
        };
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
}