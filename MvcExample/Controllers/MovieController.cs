using Application.Services;
using MvcExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Domain.Entities;
using Application.Queries;

namespace MvcExample.Controllers
{
    public class MovieController(MovieService movieService, IMovieGetByIdQueryHandler movieGetByIdQuery) : Controller
    {
        private readonly MovieService _movieService = movieService;
        private readonly IMovieGetByIdQueryHandler _movieGetByIdQuery = movieGetByIdQuery;

        public IActionResult Get(Guid id)
        {
            var movie = _movieGetByIdQuery.Handle(id).GetAwaiter().GetResult();
            return View(movie);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Movie model = new();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            _movieService.CreateAsync(movie.Name).GetAwaiter().GetResult();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
