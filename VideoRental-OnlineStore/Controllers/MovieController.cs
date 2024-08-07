using Microsoft.AspNetCore.Mvc;
using VideoRental.Services;
using VideoRental.Services.Interfaces;
using VideoRental.ViewModels;
using VideoRental_OnlineStore.Models;
using VideoRental.Mappers;

namespace VideoRental_OnlineStore.Controllers
{
    public class MovieController : Controller
    {
        private IMovieService _movieService ;
         public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult ListMovies()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            var userFullName = HttpContext.Session.GetString("UserFullName");

            var movies = _movieService.GetAllMovies();

            
            ViewData["UserFullName"] = userFullName;
            ViewData["UserId"] = userId;
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            try
            {
                var movie = _movieService.GetMovieById(id);
                return View(movie);
            }
            catch(MovieNotFoundException ex)
            {
                return RedirectToAction("ErrorMessage", new CustomErrorViewModel{Message =  ex.Message });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
            

        }
        public IActionResult ErrorMessage(CustomErrorViewModel customError)
        {
            return View(customError);
        }

    }
}
