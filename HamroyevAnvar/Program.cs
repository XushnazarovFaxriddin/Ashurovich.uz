var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapGet("/dev", () => new { Name = ".NET developer Faxriddin Xushnazarov", Tel = "+998936831555" });

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();
