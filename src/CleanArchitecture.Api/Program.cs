using CleanArchitecture.Application;
using CleanArchitecture.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddSingleton<IWorkItemRepository, InMemoryWorkItemRepository>();
builder.Services.AddScoped<IWorkItemService, WorkItemService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/health", () => Results.Ok(new { service = "clean-architecture-api", status = "healthy", timestampUtc = DateTime.UtcNow }));

app.MapGet("/api/work-items", (IWorkItemService service) => Results.Ok(service.GetAll()));

app.MapPost("/api/work-items", (CreateWorkItemRequest request, IWorkItemService service) =>
{
    try
    {
        var created = service.Create(request.Title);
        return Results.Created($"/api/work-items/{created.Id}", created);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { message = ex.Message });
    }
});

app.Run();

public sealed record CreateWorkItemRequest(string Title);
