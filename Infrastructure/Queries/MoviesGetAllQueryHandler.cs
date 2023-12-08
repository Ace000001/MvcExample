using Application.Queries;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries
{
    public sealed class MoviesGetAllQueryHandler(ApplicationDbContext dbContext) : IMoviesGetAllQueryHandler
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public List<Movie> Handle()
        {
            var movie = _dbContext.Movies.ToList();

            return movie;
        }
    }
}
