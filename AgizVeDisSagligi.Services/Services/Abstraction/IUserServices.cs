using AgizVeDisSagligi.Entity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgizVeDisSagligi.Services.Services.Abstraction
{
    public interface IUserServices
    {
        Task<List<User>> GettAllUsersAsync();
        Task<bool> CreateUserAsync(User user);
        Task<bool> CheckMail(string mail);
        Task<bool> CheckPassaword(string passaword);
        Task<User> GetUserByEmailAsync(string mail);
        Task<User> GetUserByIdlAsync(Guid ID);
        Task UpdateUserAsync(User user);
        Task<User> ValidateUserAsync(string email, string password);


    }
}
