using Flashcards.WebApp.Features;
using Flashcards.WebApp.Features.ConceptTemplates;
using Flashcards.WebApp.Infrastructure;
using Flashcards.WebApp.Shared.EFCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();
builder.Services.AddMediator(opts => opts.ServiceLifetime = ServiceLifetime.Scoped);
builder.Services.AddScoped<IRepository<ConceptTemplate, ConceptTemplateId>, DbContextRepository<ConceptTemplate, ConceptTemplateId>>();

builder.Services.AddEntityFrameworkNpgsql().AddDbContext<FlashcardsDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
