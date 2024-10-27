namespace ApplicationCore.Contracts.Repositories;

public interface IMovieRepository:IRepository<Movie>
{
    IEnumerable<Movie> GetTopRevenueMovies(int number=20);
    IEnumerable<Movie> GetMoviesWithGenre();
}