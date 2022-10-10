using HamroyevAnvar.Middlewares;
using HamroyevAnvar.Models;
using HamroyevAnvar.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

TgBot tgBot = builder.Configuration.GetSection("TgBot").Get<TgBot>();

builder.Services.AddScoped(s => new TgBotService(tgBot));


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapGet("/dev", () => new { Name = ".NET developer Faxriddin Xushnazarov", Tel = "+998936831555" });

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();
