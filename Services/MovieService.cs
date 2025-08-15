using Core;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public interface IMovieService
    {
        Task<List<MovieWithIdDTO>> GetMoviesAsync();
        Task<MovieWithIdDTO> GetMovieByIdAsync(int id);
        Task AddMovieAsync(MovieDTO movieDto);
        Task DeleteMovieByIdAsync(int id);
        Task UpdateMovieAsync(MovieWithIdDTO movieDto);
    }
    public class MovieService: IMovieService
    {
        private readonly DbDevContext _movieConetext;
        public MovieService(DbDevContext context)
        {
            _movieConetext = context;
        }
        public async Task<List<MovieWithIdDTO>> GetMoviesAsync()
        {
            var movies = await _movieConetext.Movies.ToListAsync();
            return movies.Select(m => new MovieWithIdDTO
            {
                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
                Director = m.Director
            }).ToList();

        }
        public async Task<MovieWithIdDTO> GetMovieByIdAsync(int id)
        {
            var movie = await _movieConetext.Movies.FirstOrDefaultAsync(x=>x.Id==id);
            if (movie == null) return null;

            return new MovieWithIdDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Director = movie.Director
            };
        }
        public async Task AddMovieAsync(MovieDTO movieDto)
        {
            var movie = new Movie
            {
                Title = movieDto.Title,
                Description = movieDto.Description,
                Director = movieDto.Director
            };
            _movieConetext.Movies.Add(movie);
            await _movieConetext.SaveChangesAsync();
        }
        public async Task DeleteMovieByIdAsync(int id)
        {
            var movie = await _movieConetext.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (movie != null)
            {
                _movieConetext.Movies.Remove(movie);
                _movieConetext.SaveChanges();
            }
        }
        public async Task UpdateMovieAsync(MovieWithIdDTO movieDto)
        {
            var movie = await _movieConetext.Movies.FirstOrDefaultAsync(x => x.Id == movieDto.Id);
            if (movie != null)
            {
                movie.Title = movieDto.Title;
                movie.Description = movieDto.Description;
                movie.Director = movieDto.Director;

                _movieConetext.Movies.Update(movie);
                await _movieConetext.SaveChangesAsync();
            }
        }
    }
}
