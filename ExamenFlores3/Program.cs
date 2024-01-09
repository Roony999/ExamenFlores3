using ExamenFlores3.Models.Entities;
using ExamenFlores3.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddDbContext<FloresContext>(x => x.UseMySql("server=localhost;user=root;password=root;database=flores", ServerVersion.Parse("8.0.27-mysql")));
builder.Services.AddTransient<FloresRepository>();

var app = builder.Build();



app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapDefaultControllerRoute();
app.UseStaticFiles();

app.Run();
