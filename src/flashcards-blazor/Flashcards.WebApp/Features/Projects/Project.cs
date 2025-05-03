using Flashcards.WebApp.Shared.Entities;

namespace Flashcards.WebApp.Features.Projects;

public record Project(
    ProjectId Id,
    string Name,
    string UserId,
    bool IsArchived = false) : IEntity<ProjectId>, IUserOwned, IArchived;

public record ProjectId(Guid Value) : GuidEntityId<ProjectId>;