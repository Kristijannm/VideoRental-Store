using System.Security.Cryptography.X509Certificates;
using VideoRental.DataAccess;
using VideoRental.Domain.Models;
using VideoRental.Mappers;
using VideoRental.Services.Interfaces;
using VideoRental.ViewModels;

namespace VideoRental.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private IRepository<Movie> _movieRepository;
        private ICastService _castService;
        public MovieService(IRepository<Movie> movieRepository, ICastService castService) 
        {
            _movieRepository = movieRepository;
            _castService = castService;
        }
        public List<MovieViewModel> GetAllMovies()
        {
            List<MovieViewModel> mvml = new List<MovieViewModel>();

            foreach(var movie in _movieRepository.GetAll()) 
            {
                mvml.Add(MovieMapper.ToMovieViewModel(movie));
            }
            return mvml;
        }

        public MovieViewModel GetMovieById(int id)
        {
            var movie = _movieRepository.GetById(id);
            if (movie == null)
            {
                throw new MovieNotFoundException(id);
            }
            return MovieMapper.ToMovieViewModel(movie);
        }

        public void DecreaseMovieQuantity(int movieId)
        {
            Movie movie = _movieRepository.GetById(movieId);
            movie.Quantity--;
            _movieRepository.Update(movie);
        }

        public void IncreaseMovieQuantity(int movieId)
        {
            Movie movie = _movieRepository.GetById(movieId);
            movie.Quantity++;
            _movieRepository.Update(movie);
        }
    }
}
