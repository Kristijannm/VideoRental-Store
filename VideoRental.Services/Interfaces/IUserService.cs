using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRental.ViewModels.UserViewModels;

namespace VideoRental.Services.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> GetAllUsers();

        UserViewModel GetUserById(int id);

        int RegisterNewUser(RegisterViewModel user);
    }
}
