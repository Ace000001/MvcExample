using Domain.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public sealed class MovieRepository(ApplicationDbContext dbContext) : IMovieRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public void Insert(Movie movie) => _dbContext.Set<Movie>().Add(movie);

        public async Task<Guid> InsertAsync(Movie movie)
        {
            _dbContext.Movies.Add(movie);

            await _dbContext.SaveChangesAsync();

            return movie.Id;
        }

        //public async Task<Movie?> GetByIdAsync(Guid id)
        //{
        //    return await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == id);
        //}

        //public List<Movie> GetAll()
        //{
        //    return _dbContext.Movies.ToList();
        //}
    }
}
