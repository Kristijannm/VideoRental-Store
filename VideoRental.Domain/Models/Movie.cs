using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Domain.Enum;

namespace VideoRental.Domain.Models
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public GenreEnum Genre { get; set; } // Consider using an Enum here
        public LanguageEnum Language { get; set; } // Consider using an Enum here
        public bool IsAvailable { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan Length { get; set; }
        public int AgeRestriction { get; set; }
        public int Quantity { get; set; }
        public ICollection<Cast>? Casts { get; set;}
        public ICollection<Rental>? Rentals { get; set; }

    }
}
