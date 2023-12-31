
using URL_Shortener.AutoMapperProfiles;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
// Add services to the container.
builder.Services.AddAutoMapper(typeof(AppMappingProfile));
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader()
                            .AllowAnyMethod());
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
