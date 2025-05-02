using Microsoft.AspNetCore.Identity;

namespace Flashcards.WebApp.Features.Account;

public record struct UserId(string Value);
public class ApplicationUser : IdentityUser;
