using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoRental.ViewModels.UserViewModels
{
    public class UserLoginViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
    }
}
