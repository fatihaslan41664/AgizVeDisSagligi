using AgizVeDisSagligi.Entity.Entites;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgizVeDisSagligi.Entity.DTOs;

namespace AgizVeDisSagligi.Services.Services.Abstraction
{
    public interface ISituationService
    {
        Task<List<Situation>> GetAllStatuesLastSevenDaysAsync(Guid userId);
        Task<bool> AddStatuAsync(AddSituationDto statu);
        Task<List<Situation>> GetSituationByUserIdAsync(Guid userId);
        Task DeleteAsync(Guid id);

    }
}
