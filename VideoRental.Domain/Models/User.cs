using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Domain.Enum;

namespace VideoRental.Domain.Models
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string CardNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsSubscriptionExpired { get; set; }
        public SubscriptionTypeEnum SubscriptionType { get; set; }
        public ICollection<Rental> Rentals { get; set; }
    }
}
