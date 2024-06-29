using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Account;
using api.Models;

namespace api.Mappers
{
    public static class AccountMapper
    {
        public static AccountDto ToAccountDto(this ApplicationUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return new AccountDto
            {
                Email = user.Email
            };
        }

        public static ApplicationUser ToApplicationUserFromUpdateUserDto(this UpdateUserDto updateUserDto)
        {
            if (updateUserDto == null)
            {
                throw new ArgumentNullException(nameof(updateUserDto));
            }

            return new ApplicationUser
            {
                FirstName = updateUserDto.FirstName,
                LastName = updateUserDto.LastName,
                PhoneNumber = updateUserDto.PhoneNumber,
                Address = updateUserDto.Address
            };
        }
    }
}
