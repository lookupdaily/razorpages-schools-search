using Microsoft.EntityFrameworkCore;
using SchoolPerformanceTablesMock.Data;
using SchoolPerformanceTablesMock.Models;
using SchoolPerformanceTablesMock.Repositories;
using SchoolPerformanceTablesMock.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<SchoolPerformanceTablesMockContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SchoolPerformanceTablesMockContext") ?? throw new InvalidOperationException("Connection string 'SchoolPerformanceTablesMockContext' not found.")));
builder.Services.AddTransient(typeof(ISchoolRepository), typeof(SchoolRepository));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    
    SeedData.Initialize(services);
}

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