using Application.Queries;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Queries
{
    public sealed class MovieGetByIdQueryHandler(ApplicationDbContext dbContext) : IMovieGetByIdQueryHandler
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task<Movie?> Handle(Guid id)
        {
            var movie = await _dbContext.Movies.FirstOrDefaultAsync(m => id.Equals(m.Id));

            return movie;
        }

    }
}
