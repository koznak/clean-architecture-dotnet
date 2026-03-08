# clean-architecture-dotnet

Clean Architecture sample in .NET 10 with clear layer boundaries.

## Layers

- `CleanArchitecture.Domain`
- Enterprise entities (`WorkItem`) and business rules.
- `CleanArchitecture.Application`
- Use cases and ports (`IWorkItemRepository`, `IWorkItemService`).
- `CleanArchitecture.Infrastructure`
- Adapter implementation (`InMemoryWorkItemRepository`).
- `CleanArchitecture.Api`
- Delivery layer (HTTP endpoints and dependency wiring).

## Run

```powershell
dotnet build clean-architecture-dotnet.slnx -c Release
dotnet test clean-architecture-dotnet.slnx -c Release
dotnet run --project src/CleanArchitecture.Api
```

## Endpoints

- `GET /health`
- `GET /api/work-items`
- `POST /api/work-items`

Sample request body:

```json
{
  "title": "Review clean architecture candidate sample"
}
```
"# clean-architecture-dotnet" 
