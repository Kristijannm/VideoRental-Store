using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Domain.Enum;
using VideoRental.ViewModels.UserViewModels;

namespace VideoRental.ViewModels
{
    public class CastViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PartEnum Part { get; set; }
        public int MovieId {  get; set; }
        public MovieViewModel MovieViewModel { get; set; }
        public int UserId { get; set; }
        public UserViewModel UserViewModel { get; set; }
    }
}
