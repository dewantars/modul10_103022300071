using Microsoft.AspNetCore.Mvc;
using modul10_103022300071.Models;

namespace modul10_103022300071.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private static List<Movie> movies = new List<Movie>
        {
            new Movie { Title = "The Shawshank Redemption", Director = "Frank Darabont", Stars = ["Tim Robbins", "Morgan Freeman", "Bob Gunton"], Description = "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion." },
            new Movie { Title = "The Godfather", Director = "Francis Ford Coppola", Stars = ["Marlon Brando", "Al Pacino", "James Caan"], Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son." },
            new Movie { Title = "The Dark Knight", Director = "Christopher Nolan", Stars = ["Christian Bale", "Heath Ledger", "Aaron Eckhart"], Description = "When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness." }
        };
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetAllMovie()
        {
            return Ok(movies);
        }

        [HttpGet("{index}")]
        public ActionResult<Movie> GetMovieByIndex(int index)
        {
            if (index < 0 || index >= movies.Count)
                return NotFound("Movie not found.");

            return Ok(movies[index]);
        }

        [HttpPost]
        public ActionResult AddMovie([FromBody] Movie movie)
        {
            movies.Add(movie);
            return Ok("Movie added successfully.");
        }

        [HttpDelete("{index}")]
        public ActionResult DeleteMovie(int index)
        {
            if (index < 0 || index >= movies.Count)
                return NotFound("movie not found.");

            movies.RemoveAt(index);
            return Ok("movie deleted successfully.");
        }
    }
}
