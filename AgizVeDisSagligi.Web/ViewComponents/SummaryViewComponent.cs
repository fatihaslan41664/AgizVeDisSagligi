using AgizVeDisSagligi.Services.Services.Abstraction;
using AgizVeDisSagligi.Services.Services.Concrates;
using Microsoft.AspNetCore.Mvc;

namespace AgizVeDisSagligi.Web.ViewComponents
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly IActivityService activityService;
        private readonly IUserServices userServices;
        public SummaryViewComponent(IActivityService activityService, IUserServices userServices)
        {
            this.activityService = activityService;
            this.userServices = userServices;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = HttpContext.Session.GetString("userId");

            if (string.IsNullOrEmpty(id))
            {
                return Content("Kullanıcı bilgisi bulunamadı.");
            }

            if (!Guid.TryParse(id, out Guid id1))
            {
                return Content("Geçersiz kullanıcı ID'si.");
            }

            var activities = await activityService.GetLastWeekActivitiesAsync(id1);

            if (activities == null || !activities.Any())
            {
                return Content("Son bir haftada herhangi bir aktivite bulunamadı.");
            }

            return View(activities);
        }

    }
}
