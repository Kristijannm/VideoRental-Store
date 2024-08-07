using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRental.ViewModels;

namespace VideoRental.Services.Interfaces
{
    public interface IMovieService
    {
        List<MovieViewModel> GetAllMovies();
        MovieViewModel GetMovieById(int id);
        void DecreaseMovieQuantity(int movieId);
        void IncreaseMovieQuantity(int movieId);
    }
}
