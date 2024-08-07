using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental.Domain.Models
{
    public class Rental : BaseEntity
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime RentedOn { get; set; }
        public DateTime? ReturnedOn { get; set; }
    }
}
