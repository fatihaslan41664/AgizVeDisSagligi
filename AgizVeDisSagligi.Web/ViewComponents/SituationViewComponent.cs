using AgizVeDisSagligi.Services.Services.Abstraction;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AgizVeDisSagligi.Web.ViewComponents
{
    public class SituationViewComponent : ViewComponent
    {
        private readonly ISituationService statuService;
        private readonly IUserServices userServices;

        public SituationViewComponent(ISituationService statuService, IUserServices userServices)
        {
            this.statuService = statuService;
            this.userServices = userServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var claimsUser = (ClaimsPrincipal)User;
            var id = HttpContext.Session.GetString("userId");
            Guid id1 = Guid.Parse(id);
            var kullanici = await userServices.GetUserByIdlAsync(id1);
            var goalsForStatuTab = await statuService.GetAllStatuesLastSevenDaysAsync(id1);
            return View(goalsForStatuTab);
        }
    }
}