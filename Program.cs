using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using TravelingSalesman.Data;
using TravelingSalesman.Data.Coordinate;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add mudblazor service
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddDbContextFactory<CoordinateContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("MapCoordinatesDB")));

var app = builder.Build();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CoordinateContext>();
    db.Database.EnsureCreated();
}

app.Run();
