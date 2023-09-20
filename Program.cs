using Anbar.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.StaticFiles;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyContext>(options =>
{
    options.UseSqlServer("Data Source=.;Initial Catalog=Anbardari_DB;Integrated Security=true;TrustServerCertificate=True");
});
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
