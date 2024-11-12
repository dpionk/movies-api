using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Entities;

namespace MoviesAPI.Controllers
{   
    [Route("/api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {   
        private readonly DataContext _dataContext;

        public MovieController(DataContext dataContext) { 
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetAllMovies()
        {
            var movies = await _dataContext.Movies.ToListAsync();

            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _dataContext.Movies.FindAsync(id);

            if (movie is null)
            {
                return NotFound("Movie not found");
            }

            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult<List<Movie>>> AddMovie(Movie movie)
        {
            _dataContext.Movies.Add(movie);
            await _dataContext.SaveChangesAsync();

            var movies = await _dataContext.Movies.ToListAsync();
            return Ok(movies);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Movie>>> UpdateMovie(int id, Movie movie)
        {
            var existingMovie = await _dataContext.Movies.FindAsync(id);

            if (existingMovie is null)
            {
                return NotFound("Movie not found");
            }

            existingMovie.Title = movie.Title;
            existingMovie.Director = movie.Director;
            existingMovie.year = movie.year;
            existingMovie.rate = movie.rate;

            await _dataContext.SaveChangesAsync();

            var movies = _dataContext.Movies.ToListAsync();

            return Ok(movies);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Movie>>> DeleteMovie(int id)
        {
            var existingMovie = await _dataContext.Movies.FindAsync(id);

            if (existingMovie is null)
            {
                return NotFound("Movie not found");
            }

            _dataContext.Movies.Remove(existingMovie);
            await _dataContext.SaveChangesAsync();

            var movies = _dataContext.Movies.ToListAsync();
            return Ok(movies);

        }
    }
}
