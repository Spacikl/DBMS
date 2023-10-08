using Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
var app = builder.Build();


app.MapControllers();
app.MapDefaultControllerRoute();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Db}/{action=ShowAllDataBases}");
app.Run();
