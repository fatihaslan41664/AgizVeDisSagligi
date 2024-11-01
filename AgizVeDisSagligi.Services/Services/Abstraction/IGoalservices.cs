using AgizVeDisSagligi.Entity.DTOs;
using AgizVeDisSagligi.Entity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgizVeDisSagligi.Services.Services.Abstraction
{
    public interface  IGoalservices
    {
        Task<bool> CreateGoalAsync(AddGoalDto addgoalDto);
        Task<List<Goal>> GetAllGoalsAsync();
        Task<List<Goal>> GetGoalsByUserIdAsync(Guid userId);
        Task DeleteAsync(Guid id);

    }
}
