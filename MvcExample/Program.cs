using Application.Queries;
using Application.Services;
using Domain.Repositories;
using Infrastructure;
using Infrastructure.Queries;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using MvcExample.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvcCore();

//Register services
builder.Services.AddScoped<MovieService>();

//Register repos and queries
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieGetByIdQueryHandler, MovieGetByIdQueryHandler>();
builder.Services.AddScoped<IMoviesGetAllQueryHandler, MoviesGetAllQueryHandler>();

//Register Db Context
builder.Services.AddDbContext<ApplicationDbContext>(o => 
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the view component
builder.Services.AddTransient<MoviesViewComponent>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Movie/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movie}/{action=Create}/{id?}");

app.Run();
