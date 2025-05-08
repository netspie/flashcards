namespace Flashcards.WebApp.Shared.Entities;

public class NotFoundException(string message) : Exception(message) { }