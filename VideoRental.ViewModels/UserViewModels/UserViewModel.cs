using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Domain.Enum;
using VideoRental.Domain.Models;

namespace VideoRental.ViewModels.UserViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string CardNumber { get; set; }
        public bool IsSubscriptionExpired { get; set; }
        public SubscriptionTypeEnum SubscriptionType { get; set; }
        public ICollection<Rental> Rentals { get; set; }
    }
}
