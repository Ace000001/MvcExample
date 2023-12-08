using Application.Queries;
using Application.Services;
using Infrastructure.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MvcExample.Components
{
    public class MoviesViewComponent(IMoviesGetAllQueryHandler moviesGetAllQueryHandler) : ViewComponent
    {
        private readonly IMoviesGetAllQueryHandler _moviesGetAllQueryHandler = moviesGetAllQueryHandler;

        public IViewComponentResult Invoke()
        {
            var Movies = _moviesGetAllQueryHandler.Handle();

            return View(Movies);
        }
    }
}