using Flashcards.WebApp.Features;
using Flashcards.WebApp.Features.Account;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Flashcards.WebApp.Infrastructure.Data;
using Flashcards.WebApp.Shared.DDD;
using Flashcards.WebApp.Features.Projects;
using Flashcards.WebApp.Shared.EntityFrameworkCore;
using Mediator;
using Flashcards.WebApp.Infrastructure.RequestHandlerBehaviours;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

// Flashcards App
builder.Services.AddMediator(opts => opts.ServiceLifetime = ServiceLifetime.Scoped);
builder.Services.AddScoped<IRepository<Project, ProjectId>>(sp => new DbContextRepository<Project, ProjectId>(sp.GetRequiredService<DbContext>(), "projects"));
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(BlazorServerUserIdInjectionBehavior<,>));

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
.AddIdentityCookies();

builder.Services
    .AddEntityFrameworkNpgsql()
    .AddDbContext<ApplicationDbContext>()
    .AddScoped<DbContext, ApplicationDbContext>(); // optional (I use it to inject into generic repo)

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
