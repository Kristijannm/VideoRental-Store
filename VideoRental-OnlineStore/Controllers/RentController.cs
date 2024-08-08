using Microsoft.AspNetCore.Mvc;
using VideoRental.Services.Interfaces;
using VideoRental.ViewModels;
using VideoRental_OnlineStore.Models;

namespace VideoRental_OnlineStore.Controllers
{
    public class RentController : Controller
    {
        private IRentalService _rentalService;
        private IMovieService _movieService;
        public RentController(IRentalService rentalService, IMovieService movieService)
        {
            _rentalService = rentalService;
            _movieService = movieService;
        }

        public IActionResult RentMovie(int Id)
        {
            int? userId = HttpContext.Session.GetInt32("UserId"); //user currently logged in
            int rentalId = _rentalService.CreateRental(userId.Value, Id);
            if (rentalId != null)
            {
                _movieService.DecreaseMovieQuantity(Id);
                return RedirectToAction("UserRentals", new { userId = userId.Value });
            }
            return RedirectToAction("ErrorMessage", new CustomErrorViewModel { Message = "Something went wrong while truing to proceed your action." });

        }

        public IActionResult UserRentals(int userId)
        {
            List<RentalViewModel> userRentals = _rentalService.GetAllRentalsForUser(userId);
            userRentals.Reverse(); // getting the new ones on top

            return View(userRentals);
        }

        public IActionResult ReturnMovie(int rentalId, int userId, int movieId)
        {

            RentalViewModel rental = _rentalService.GetRentalById(rentalId);
            if (rental != null && rental.MovieId == movieId && rental.UserId == userId)
            {
                bool succeed = _rentalService.ReturnMovie(rentalId, userId, movieId);
                if (succeed)
                    _movieService.IncreaseMovieQuantity(movieId);
                return RedirectToAction("UserRentals", new { userId = userId });
            }
            return View("Error");

        }
    }
}
