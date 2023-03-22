using BibliotecaWebApp.Database;
using BibliotecaWebApp.Service;
using Forge.OpenAI;
using Forge.OpenAI.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext <AppDbContext> (options =>
    options.UseSqlServer("Data Source=(localdb)\\DBTest;Initial Catalog=biblioteca;Integrated Security=True"));
builder.Services.AddHttpClient<GetExternalAPIBiblioteca>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7077/Biblioteca");
});

builder.Services.AddForgeOpenAI(options => {
    options.AuthenticationInfo = builder.Configuration["OpenAI:ApiKey"]!;
});

using var host = Host.CreateDefaultBuilder(args)
        .ConfigureServices((builder, services) =>
        {
            services.AddForgeOpenAI(options => {
                options.AuthenticationInfo = builder.Configuration["OpenAI:ApiKey"]!;
            });
        })
        .Build();

IOpenAIService openAi = host.Services.GetService<IOpenAIService>()!;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HomeBiblioteca}/{action=Index}/{id?}");

app.Run();
