using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Helper;
using WebApp.Model;
using WebApp.Repository;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ScheduledEventRepo>();
builder.Services.AddScoped<EventAttendeeRepo>();
builder.Services.AddScoped<UserRepo>();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<DataContext>();

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder(RouteName.ScheduledEvents);
    options.Conventions.AuthorizeFolder(RouteName.MyData);
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();