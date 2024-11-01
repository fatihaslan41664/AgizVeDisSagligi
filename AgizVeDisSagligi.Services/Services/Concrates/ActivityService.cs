using AgizVeDisSagligi.Data.Context;
using AgizVeDisSagligi.Data.UnitOfWorks;
using AgizVeDisSagligi.Entity.Entites;
using AgizVeDisSagligi.Services.Services.Abstraction;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgizVeDisSagligi.Services.Services.Concrates
{
    public class ActivityService : IActivityService
    {
        private readonly IUnitOfWork unitOfWork;

        public ActivityService(IUnitOfWork unitOfWork,
           AppDbContext context)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<object>> GetLastWeekActivitiesAsync(Guid id)
        {
            var oneWeekAgo = DateOnly.FromDateTime(DateTime.Now.AddDays(-7));


            var recentGoals = await unitOfWork.GetRepository<Goal>()
                .GetAllAsync(g => g.UserId == id && g.CreatedDate >= oneWeekAgo);


            var recentStatuses = await unitOfWork.GetRepository<Situation>()
                .GetAllAsync(s => s.Goal.UserId == id && s.CreatedDate >= oneWeekAgo);



            var recentActivities = recentGoals.Cast<object>().Concat(recentStatuses.Cast<object>()).ToList();

            return recentActivities;
        }
    }
}
