using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental.ViewModels.UserViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [Range(14, 120, ErrorMessage = "Age must be between 14 and 120.")]
        public int Age { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "Card number must be exactly 16 characters long.", MinimumLength = 16)]
        [RegularExpression(@"\d{16}", ErrorMessage = "Card number must be exactly 16 digits.")]
        public string CardNumber { get; set; }

       
    }
}
