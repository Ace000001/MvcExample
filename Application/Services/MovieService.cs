using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public sealed class MovieService(IMovieRepository repository)
    {
        private readonly IMovieRepository _repository = repository;

        public async Task<Guid> CreateAsync(string name)
        {
            var movie = new Movie
            {
                Id = Guid.NewGuid(),
                Name = name
            };

            var movieId = await _repository.InsertAsync(movie);

            return movieId;
        }

        //public async Task<Movie?> GetByIdAsync(Guid id)
        //{
        //    var movie = await _repository.GetByIdAsync(id);

        //    return movie;
        //}

        //public List<Movie> GetAll()
        //{
        //    var movies = _repository.GetAll();

        //    return movies;
        //}
    }
}
