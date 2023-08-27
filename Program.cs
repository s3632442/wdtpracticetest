using EdInstitution.BackgroundServices;
using EdInstitution.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<InstitutionContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("InstitutionContext"));
    
});

builder.Services.AddHostedService<CourseInstructorBackgroundService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        SeedData.Initialize(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the DB");
    }
}


// // Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/Home/Error");
//     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//     app.UseHsts();
// }

// app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// app.UseAuthorization();

app.MapDefaultControllerRoute();
// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
