using Core;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        // GET: api/<MovieController>
        [HttpGet]
        public async Task<List<MovieWithIdDTO>> Get()
        {
            var movies= await _movieService.GetMoviesAsync();
            return movies;
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public async Task<MovieWithIdDTO> Get(int id)
        {
            try
            {
                var movie = await _movieService.GetMovieByIdAsync(id);
                return movie;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // POST api/<MovieController>
        [HttpPost]
        public async Task<IActionResult> Post(MovieDTO movie)
        {
            if (movie == null)
            {
                return BadRequest("Movie cannot be null");
            }
            try
            {
                await _movieService.AddMovieAsync(movie);
                return Ok("Add succsesful");
            }
            catch
            {
                return BadRequest("Error while adding movie");
            }
        }

        // PUT api/<MovieController>/5
        [HttpPut]
        public async Task<IActionResult> Put(MovieWithIdDTO movie)
        {
            try
            {

                await _movieService.UpdateMovieAsync(movie);
                return Ok("Modifaied succsesful");
            }
            catch (Exception ex) {
                return BadRequest("Error while updating movie");
            }
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _movieService.DeleteMovieByIdAsync(id);
            return Ok("Deleted succsesful");
        }
    }
}
