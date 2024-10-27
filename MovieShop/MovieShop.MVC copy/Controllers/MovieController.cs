namespace MovieShop.Controllers;

public class MoviesController : Controller
{
    private readonly IMovieService _movieService;
        
    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }
        
    public IActionResult Index()
    {
        var movies = _movieService.GetTopGrossingMovies();
        return View(movies);
    }
}