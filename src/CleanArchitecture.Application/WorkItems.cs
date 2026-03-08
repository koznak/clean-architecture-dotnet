using CleanArchitecture.Domain;

namespace CleanArchitecture.Application;

public interface IWorkItemRepository
{
    IReadOnlyList<WorkItem> GetAll();
    WorkItem Add(WorkItem item);
}

public interface IWorkItemService
{
    IReadOnlyList<WorkItem> GetAll();
    WorkItem Create(string title);
}

public sealed class WorkItemService(IWorkItemRepository repository) : IWorkItemService
{
    public IReadOnlyList<WorkItem> GetAll() => repository.GetAll();

    public WorkItem Create(string title)
    {
        var item = WorkItem.Create(title);
        return repository.Add(item);
    }
}
