using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Domain.Enum;
using VideoRental.Domain.Models;

namespace VideoRental.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public GenreEnum Genre { get; set; }
        public LanguageEnum Language { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan Length { get; set; }
        public int Quantity { get; set; }
        public int AgeRestriction { get; set; }
        public ICollection<CastViewModel> Casts { get; set; }
        public ICollection<RentalViewModel> Rentals { get; set; }


    }
}
