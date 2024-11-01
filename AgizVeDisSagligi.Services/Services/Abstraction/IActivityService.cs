using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgizVeDisSagligi.Services.Services.Abstraction
{
    public interface IActivityService
    {
        Task<List<object>> GetLastWeekActivitiesAsync(Guid id);
    }
}
