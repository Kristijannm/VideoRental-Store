using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using VideoRental.DataAccess;
using VideoRental.Domain.Models;
using VideoRental.Mappers;
using VideoRental.Services.Interfaces;
using VideoRental.ViewModels;

namespace VideoRental.Services.Implementations
{
    public class RentalService : IRentalService
    {
        public IRepository<Rental> _rentalRepository;
        public IMovieService _movieService;
        public IUserService _userService;
        public RentalService(IRepository<Rental> rentalRepository,IMovieService movieService, IUserService userService) 
        { 
            _rentalRepository = rentalRepository;
            _movieService = movieService;
            _userService = userService;
        }
        public List<RentalViewModel> GetAllRentals()
        {
            List<RentalViewModel> rvml = new List<RentalViewModel>();

            foreach(var r in _rentalRepository.GetAll())
            {
                rvml.Add(RentalMapper.ToRentalViewModel(r));
            }
            return rvml;
        }

        public List<RentalViewModel> GetAllRentalsForUser(int userId)
        {
            List<RentalViewModel> rentals = new List<RentalViewModel> { };
            List<Rental> rentalsDomain = _rentalRepository.GetAll();

            foreach(var r in rentalsDomain)
            {
                if(r.UserId == userId)
                {
                    RentalViewModel rentalViewModel = RentalMapper.ToRentalViewModel(r);
                    rentalViewModel.MovieViewModel = _movieService.GetMovieById(rentalViewModel.MovieId);
                    rentalViewModel.UserViewModel = _userService.GetUserById(rentalViewModel.UserId);
                    rentals.Add(rentalViewModel);
                }
            }
            return rentals;
        }

        public RentalViewModel GetRentalById(int id)
        {
            RentalViewModel rental = RentalMapper.ToRentalViewModel(_rentalRepository.GetById(id));
            return rental;
        }

        public int CreateRental(int userId, int movieId)
        {
            RentalViewModel rent = new RentalViewModel
            {
                UserId = userId,
                MovieId = movieId,
                RentedOn = DateTime.Now,
                MovieViewModel = _movieService.GetMovieById(movieId),
                UserViewModel = _userService.GetUserById(userId)
            };
            
            int rentalId = _rentalRepository.Insert(RentalMapper.ToRentalFromRentalViewModel(rent));
            return rentalId;

        }

        public bool ReturnMovie(int rentalId ,int userId, int movieId)
        {
            Rental? closeRentalDomain = _rentalRepository.GetAll()
                                                        .FirstOrDefault(x => x.Id == rentalId && x.MovieId == movieId && x.UserId == userId);
            

            if (closeRentalDomain != null)
            {
                closeRentalDomain.ReturnedOn = DateTime.Now;
                _rentalRepository.Update(closeRentalDomain);

                return true;
            }
            return false;
            
        }
    }
}
