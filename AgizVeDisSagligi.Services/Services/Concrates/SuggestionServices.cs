using AgizVeDisSagligi.Data.Reporsitories.Abstract;
using AgizVeDisSagligi.Data.UnitOfWorks;
using AgizVeDisSagligi.Entity.Entites;
using AgizVeDisSagligi.Services.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgizVeDisSagligi.Services.Services.Concrates
{
    public class SuggestionServices : ISuggestionService
    {
        
        private readonly IUnitOfWork unitOfWork;
        public SuggestionServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Suggestion> GetRandomSuggestionAsync()
        {
            return await unitOfWork.GetRepository<Suggestion>().GetRandomSuggestionAsync();
        }
    }
}
