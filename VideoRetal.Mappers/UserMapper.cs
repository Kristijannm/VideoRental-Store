using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoRental.Domain.Enum;
using VideoRental.Domain.Models;
using VideoRental.ViewModels.UserViewModels;

namespace VideoRental.Mappers
{
    public static class UserMapper
    {
        public static UserViewModel ToUserViewModel(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                FullName = user.FullName,
                Age = user.Age,
                CardNumber = user.CardNumber,
                IsSubscriptionExpired = user.IsSubscriptionExpired,
                SubscriptionType = user.SubscriptionType,
                Rentals = user.Rentals,
            };
        }

        public static UserLoginViewModel ToUserLoginViewModel(User user)
        {
            return new UserLoginViewModel
            {
                Id = user.Id,
                CardNumber = user.CardNumber,
                FullName = user.FullName
            };
        }

        public static User ToUserFromRegisterViewModel(RegisterViewModel registerViewModel)
        {
            return new User
            {
                FullName = registerViewModel.FullName,
                Age = registerViewModel.Age,
                CardNumber = registerViewModel.CardNumber,
                CreatedOn = DateTime.Now,
                IsSubscriptionExpired = false,
                SubscriptionType = SubscriptionTypeEnum.Weekly,
            };
        }
    }
}
