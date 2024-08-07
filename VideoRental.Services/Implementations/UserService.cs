using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRental.DataAccess;
using VideoRental.Domain.Models;
using VideoRental.Services.Interfaces;
using VideoRental.ViewModels.UserViewModels;
using VideoRental.Mappers;

namespace VideoRental.Services.Implementations
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserViewModel> GetAllUsers()
        {
            List<UserViewModel> uvml = new List<UserViewModel>();

            foreach(var user in _userRepository.GetAll())
            {
                uvml.Add(UserMapper.ToUserViewModel(user));
            } 
            return uvml;
        }

        public UserViewModel GetUserById(int id) 
        {
            var User = _userRepository.GetById(id);
            return UserMapper.ToUserViewModel(User);
        }

        public int RegisterNewUser(RegisterViewModel user)
        {
            if(user == null)
                throw new ArgumentNullException(nameof(user));

            User newUser = UserMapper.ToUserFromRegisterViewModel(user);
            int userId = _userRepository.Insert(newUser);
            return userId;
            
        }
    }
}
