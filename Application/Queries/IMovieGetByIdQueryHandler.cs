using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public interface IMovieGetByIdQueryHandler
    {
        Task<Movie?> Handle(Guid id);
    }
}
