using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Entities;

namespace MoviesAPI.Controllers
{   
    [Route("/api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    year = 2020,
                    rate = 1.0
                }
            };

            return Ok(movies);
        }
    }
}
