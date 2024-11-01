using AgizVeDisSagligi.Data.UnitOfWorks;
using AgizVeDisSagligi.Entity.DTOs;
using AgizVeDisSagligi.Entity.Entites;
using AgizVeDisSagligi.Services.Services.Abstraction;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgizVeDisSagligi.Services.Services.Concrates
{
    public class Goalservices : IGoalservices
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public Goalservices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> CreateGoalAsync(AddGoalDto addgoalDto)
        {
            try
            {

                var mappedGoal = mapper.Map<Goal>(addgoalDto);

                // Goal entity'sini veritabanına ekleme
                await unitOfWork.GetRepository<Goal>().AddAsync(mappedGoal);
                await unitOfWork.SaveAsycn();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Goal>> GetAllGoalsAsync()
        {
            return await unitOfWork.GetRepository<Goal>().GetAllAsync();
        }

        public async Task<List<Goal>> GetGoalsByUserIdAsync(Guid userId)
        {
            var userGoals = await unitOfWork.GetRepository<Goal>().GetAllAsync(g => g.UserId == userId);

            return userGoals; 
        }
        public async Task DeleteAsync(Guid id)
        {
            var situation = await unitOfWork.GetRepository<Goal>().GetByGuidAsync(id);

            // Eğer durum bulunamazsa, işlem yapılmaz
            if (situation == null)
                throw new Exception("Situation not found");

            // Bulunan durumu silme işlemi
            await unitOfWork.GetRepository<Goal>().DeleteAsync(situation);
            await unitOfWork.SaveAsycn();
        }
        }
    }
