using AgizVeDisSagligi.Entity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgizVeDisSagligi.Services.Services.Abstraction
{
    public interface ISuggestionService
    {
        Task<Suggestion> GetRandomSuggestionAsync();
    }
}
