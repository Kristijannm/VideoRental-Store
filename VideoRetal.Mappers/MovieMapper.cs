using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Domain.Enum;
using VideoRental.Domain.Models;
using VideoRental.ViewModels;

namespace VideoRental.Mappers
{
    public static class MovieMapper
    {
        public static MovieViewModel ToMovieViewModel(Movie movie)
        {
            return new MovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                Language = movie.Language,
                Length = movie.Length,
                Quantity = movie.Quantity,
                IsAvailable = movie.IsAvailable,
                ReleaseDate = movie.ReleaseDate,
                AgeRestriction = movie.AgeRestriction,
                Rentals = RentalMapper.ToRentalViewModelList(movie.Rentals),
                Casts = CastMapper.ToCastViewModelList(movie.Casts),
            };
            
        }
    }
}
