using Flashcards.WebApp.Shared.Entities;

namespace Flashcards.WebApp.Features.Projects;

public record struct ProjectId(Guid Value);
public record Project(
    ProjectId Id,
    string Name,
    string UserId,
    bool IsArchived = false) : IEntity<ProjectId>, IUserOwned, IArchived;
