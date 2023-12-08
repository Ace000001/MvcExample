using Domain.Entities;

namespace Domain.Repositories
{
    public interface IMovieRepository
    {
        Task<Guid> InsertAsync(Movie movie);
        //Task<Movie?> GetByIdAsync(Guid id);
        //public List<Movie> GetAll();
    }
}
