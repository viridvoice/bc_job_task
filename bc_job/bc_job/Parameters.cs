namespace bc_job;

public static class Parameters
{
    public const string FeedUrl = "https://api.actionnetwork.com/web/v1/books";
    public static readonly string? RootUrl = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName;
    
    public const bool Filter = true;
    public const bool Group = true;
    public const bool StoreToFile = true;
    public static readonly string[] AcceptedAnswers = ["y", "ye", "yes"];
}