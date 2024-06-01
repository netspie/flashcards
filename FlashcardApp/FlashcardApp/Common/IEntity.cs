namespace FlashcardApp.Common;

public interface IEntity
{
    uint Version { get; set; }
    string Id { get; }
}
