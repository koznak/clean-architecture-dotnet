using CleanArchitecture.Application;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Tests;

public class WorkItemServiceTests
{
    [Fact]
    public void Create_AddsItemToRepository()
    {
        var repo = new FakeRepository();
        var service = new WorkItemService(repo);

        var created = service.Create("First clean architecture task");

        Assert.Equal("First clean architecture task", created.Title);
        Assert.Single(repo.Items);
    }

    [Fact]
    public void Create_Throws_WhenTitleEmpty()
    {
        var repo = new FakeRepository();
        var service = new WorkItemService(repo);

        Assert.Throws<ArgumentException>(() => service.Create("   "));
    }

    private sealed class FakeRepository : IWorkItemRepository
    {
        public List<WorkItem> Items { get; } = [];

        public IReadOnlyList<WorkItem> GetAll() => Items;

        public WorkItem Add(WorkItem item)
        {
            Items.Add(item);
            return item;
        }
    }
}
