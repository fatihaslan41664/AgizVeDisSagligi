using AgizVeDisSagligi.Data.UnitOfWorks;
using AgizVeDisSagligi.Entity.Entites;
using AgizVeDisSagligi.Services.Helpers;
using AgizVeDisSagligi.Services.Services.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AgizVeDisSagligi.Services.Services.Concrates
{
    public class UserServices : IUserServices
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IPassawordHelper passawordHelper;

        public UserServices(IUnitOfWork unitOfWork, IPassawordHelper passawordHelper)
        {
            this.unitOfWork = unitOfWork;
            this.passawordHelper = passawordHelper;
        }

        public async Task<bool> CheckMail(string mail)
        {
            return await unitOfWork.GetRepository<User>().AnyAsync(x => x.Mail == mail);
        }

        public async Task<bool> CheckPassaword(string passaword)
        {
            return await unitOfWork.GetRepository<User>().AnyAsync(x => x.Passaword == passaword);
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            try
            {
                // Şifreyi hashle ve hashlenmiş hali User nesnesine ata
                user.Passaword = passawordHelper.HashPassword(user.Passaword);

                await unitOfWork.GetRepository<User>().AddAsync(user);
                await unitOfWork.SaveAsycn();
                return true;
            }
            catch (Exception ex)
            {
                // Hata durumunda false döndür
                return false;
            }
        }


        public async Task<List<User>> GettAllUsersAsync()
        {
            return await unitOfWork.GetRepository<User>().GetAllAsync();
        }

        public async Task<User> GetUserByEmailAsync(string mail)
        {
            return await unitOfWork.GetRepository<User>().GetAsync(u => u.Mail == mail);
        }

        public async Task<User> GetUserByIdlAsync(Guid ID)
        {
            return await unitOfWork.GetRepository<User>().GetAsync(u => u.ID == ID);
        }

        public async Task UpdateUserAsync(User user)
        {
            try
            {
                await unitOfWork.GetRepository<User>().UpdateAsync(user);  // Kullanıcıyı güncelle
                await unitOfWork.SaveAsycn();  // Değişiklikleri veritabanına kaydet
            }
            catch (Exception ex)
            {
                // Hata yönetimi için uygun bir işlem yapabilirsiniz
                throw new Exception("Kullanıcı güncellenirken bir hata oluştu", ex);
            }
        }
        public async Task<User> ValidateUserAsync(string email, string password)
{
    var user = await GetUserByEmailAsync(email);
    if (user == null)
        return null;

    // Şifreyi doğrula
    bool isPasswordValid = passawordHelper.VerifyPassword(password, user.Passaword);
    return isPasswordValid ? user : null;
}

        
    }
}
