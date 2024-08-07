using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRental.ViewModels;

namespace VideoRental.Services.Interfaces
{
    public interface IRentalService
    {
        List<RentalViewModel> GetAllRentals();
        List<RentalViewModel> GetAllRentalsForUser(int userId);
        RentalViewModel GetRentalById(int id);
        int CreateRental(int userId, int movieId);
        bool ReturnMovie(int rentalId, int userId, int movieId);
    }
}
