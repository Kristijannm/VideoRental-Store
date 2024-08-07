using VideoRental.Domain.Models;
using VideoRental.ViewModels;


namespace VideoRental.Mappers
{
   public static class RentalMapper
    {
        public static RentalViewModel ToRentalViewModel(Rental rental)
        {
            return new RentalViewModel
            {
                Id = rental.Id,
                MovieId = rental.MovieId,
                MovieViewModel = MovieMapper.ToMovieViewModel(rental.Movie),
                UserId = rental.UserId,
                UserViewModel = UserMapper.ToUserViewModel(rental.User),
                RentedOn = rental.RentedOn,
                ReturnedOn = rental.ReturnedOn != null ? rental.ReturnedOn.Value : null,
            };
        }
        
        public static List<RentalViewModel> ToRentalViewModelList(ICollection<Rental>? rentals)
        {
            var rentViewModels = new List<RentalViewModel>();
            if(rentals != null)
            {
                foreach (var rental in rentals)
                {
                    rentViewModels.Add(new RentalViewModel{

                        Id = rental.Id,
                        MovieId = rental.MovieId,
                        UserId = rental.UserId,
                        RentedOn = rental.RentedOn,
                        ReturnedOn = rental.ReturnedOn != null ? rental.ReturnedOn.Value : null,
                        //MovieViewModel = MovieMapper.ToMovieViewModel(rental.Movie),
                        //UserViewModel = UserMapper.ToUserViewModel(rental.User),
                        });
                    }

                return rentViewModels;
            }
            else
            {
                return new List<RentalViewModel>();
            }
            
            
        }

        public static Rental ToRentalFromRentalViewModel(RentalViewModel rental)
        {
            return new Rental
            {
                MovieId = rental.MovieId,
                UserId = rental.UserId,
                RentedOn = rental.RentedOn,
                Id = rental.Id,
            };
        }
    }
}
