using AgizVeDisSagligi.Entity.Entites;
using AgizVeDisSagligi.Services.Helpers;
using AgizVeDisSagligi.Services.Services.Abstraction;
using AgizVeDisSagligi.Services.Services.Concrates;
using Microsoft.AspNetCore.Mvc;

namespace AgizVeDisSagligi.Web.Controllers
{
    public class AnaSayfaController : Controller
    {
        private readonly IUserServices services;
        public AnaSayfaController(IUserServices services)
        {
            this.services = services;
        }

        public IActionResult MainPage()
        {
            var username = HttpContext.Session.GetString("username");
            var SurName =  HttpContext.Session.GetString("Surname");
            ViewBag.Username = username;
            ViewBag.SurName = SurName;
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login", "LoginRegister");
        }
        
        [HttpGet]
        public async Task<IActionResult> Profile() 
        {
            var id = HttpContext.Session.GetString("userId");
            Guid id1 = Guid.Parse(id);
            var user = await services.GetUserByIdlAsync(id1);
            return View(user); 
        }
        public async Task<IActionResult> Guncelleme()
        {
            var id = HttpContext.Session.GetString("userId");
            Guid id1 = Guid.Parse(id);
            var user = await services.GetUserByIdlAsync(id1);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Guncelleme(User user ,string mail,string surname , string name, string passaword, DateOnly birtdate)
        {
            user.Mail = mail;
            user.SurName = surname;
            user.BirthDate = birtdate;
            user.Name = name;
            if (user == null)
            {
                // Eğer kullanıcı null ise hata mesajı ekle
                ModelState.AddModelError("", "Kullanıcı bilgileri boş olamaz.");
                return View(user); // Bu sayede form verisi tekrar yüklenir
            }

            if (!await services.CheckMail(user.Mail))
            {
                await services.UpdateUserAsync(user);
                return RedirectToAction("MainPage", "AnaSayfa");
            }

            ModelState.AddModelError("", "Bu e-posta adresi ile zaten bir hesap mevcut.");
            return View(user);
        }

    }

}
