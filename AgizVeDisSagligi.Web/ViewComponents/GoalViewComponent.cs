using AgizVeDisSagligi.Services.Services.Abstraction;
using AgizVeDisSagligi.Services.Services.Concrates;
using Microsoft.AspNetCore.Mvc;

namespace AgizVeDisSagligi.Web.ViewComponents
{
    public class GoalViewComponent : ViewComponent
    {
        private readonly IGoalservices goalservices;
        public GoalViewComponent(IGoalservices goalservices)
        {
            this.goalservices = goalservices;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = HttpContext.Session.GetString("userId");

            Guid userId = Guid.Parse(id);
            var userGoals = await goalservices.GetGoalsByUserIdAsync(userId);
            return View(userGoals);
        }
    }
}
