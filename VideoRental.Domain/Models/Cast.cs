using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Domain.Enum;

namespace VideoRental.Domain.Models
{
    public class Cast : BaseEntity
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public string Name { get; set; }
        public PartEnum Part { get; set; } // Consider using an Enum here
    }
}
