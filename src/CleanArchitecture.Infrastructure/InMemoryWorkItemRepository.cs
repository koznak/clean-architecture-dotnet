using CleanArchitecture.Application;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Infrastructure;

public sealed class InMemoryWorkItemRepository : IWorkItemRepository
{
    private readonly List<WorkItem> _items =
    [
        WorkItem.Create("Prepare architecture notes"),
        WorkItem.Create("Write API walkthrough")
    ];

    public IReadOnlyList<WorkItem> GetAll() => _items.OrderByDescending(x => x.CreatedUtc).ToList();

    public WorkItem Add(WorkItem item)
    {
        _items.Add(item);
        return item;
    }
}
