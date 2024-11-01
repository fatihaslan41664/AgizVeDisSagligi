using AgizVeDisSagligi.Data.UnitOfWorks;
using AgizVeDisSagligi.Entity.DTOs;
using AgizVeDisSagligi.Entity.Entites;
using AgizVeDisSagligi.Services.Services.Abstraction;
using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgizVeDisSagligi.Services.Services.Concrates
{
    public class SituationServices : ISituationService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        public SituationServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> AddStatuAsync(AddSituationDto statu)
        {
            try
            {
                var mappedstatu = mapper.Map<Situation>(statu);

                // Goal entity'sini veritabanına ekleme
                await unitOfWork.GetRepository<Situation>().AddAsync(mappedstatu);
                await unitOfWork.SaveAsycn();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var situation = await unitOfWork.GetRepository<Situation>().GetByGuidAsync(id);

            // Eğer durum bulunamazsa, işlem yapılmaz
            if (situation == null)
                throw new Exception("Situation not found");

            // Bulunan durumu silme işlemi
            await unitOfWork.GetRepository<Situation>().DeleteAsync(situation);
            await unitOfWork.SaveAsycn();
        }

        public async Task<List<Situation>> GetAllStatuesLastSevenDaysAsync(Guid userId)
        {
            return await unitOfWork.GetRepository<Situation>().GetAllAsync();
        }

        public async Task<List<Situation>> GetSituationByUserIdAsync(Guid userId)
        {
            var SituationUser = await unitOfWork.GetRepository<Situation>().GetAllAsync(g => g.UserId == userId);
            return SituationUser;
        }
        

    }
}
