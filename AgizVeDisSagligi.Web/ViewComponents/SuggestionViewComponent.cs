using AgizVeDisSagligi.Entity.Entites;
using AgizVeDisSagligi.Services.Services.Abstraction;
using AgizVeDisSagligi.Services.Services.Concrates;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AgizVeDisSagligi.Web.ViewComponents
{
    public class SuggestionViewComponent : ViewComponent
    {
        private readonly ISuggestionService suggestionservice;
        public SuggestionViewComponent(ISuggestionService suggestionservice)
        {
            this.suggestionservice = suggestionservice;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var suggestion = await suggestionservice.GetRandomSuggestionAsync();

            // Eğer suggestion null ise, uygun bir mesaj veya varsayılan bir değer dönebilirsiniz.
            if (suggestion == null)
            {
                return View(new Suggestion { Recommendation = "No suggestions available." });
            }

            return View(suggestion);
        }


    }
}
