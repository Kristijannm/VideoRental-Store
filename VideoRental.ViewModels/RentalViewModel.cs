using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRental.ViewModels.UserViewModels;

namespace VideoRental.ViewModels
{
    public class RentalViewModel
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public MovieViewModel MovieViewModel { get; set; }
        public int UserId { get; set; }
        public UserViewModel UserViewModel { get; set; }
        public DateTime RentedOn { get; set; }
        public DateTime? ReturnedOn { get; set; }
    }
}
