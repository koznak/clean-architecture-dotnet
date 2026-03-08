namespace CleanArchitecture.Domain;

public sealed record WorkItem(Guid Id, string Title, bool IsDone, DateTime CreatedUtc)
{
    public static WorkItem Create(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title is required.", nameof(title));
        }

        return new WorkItem(Guid.NewGuid(), title.Trim(), false, DateTime.UtcNow);
    }
}
