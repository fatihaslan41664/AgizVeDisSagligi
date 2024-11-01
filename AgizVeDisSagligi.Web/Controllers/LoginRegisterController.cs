using AgizVeDisSagligi.Data.Context;
using AgizVeDisSagligi.Entity.DTOs;
using AgizVeDisSagligi.Entity.Entites;
using AgizVeDisSagligi.Services.Helpers;
using AgizVeDisSagligi.Services.Services.Abstraction;
using AutoMapper;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;

namespace AgizVeDisSagligi.Web.Controllers
{
    public class LoginRegisterController : Controller
    {
        private readonly ILogger<LoginRegisterController> _logger;
        private readonly IUserServices userservices;
        private readonly IMapper mapper;
         
        private readonly IEmailSender emailSender;

        public LoginRegisterController(IUserServices userservices, IEmailSender emailSender)
        {
            this.userservices = userservices;
             
            this.emailSender = emailSender;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (!ModelState.IsValid) // ModelState kontrolü
            {
                return View(user);
            }

            if (!await userservices.CheckMail(user.Mail))
            {
                await userservices.CreateUserAsync(user);
                await emailSender.SendEmailAsync(user.Mail,"kayit", "kayit basarili");
                return RedirectToAction("Login", "LoginRegister");
            }
            else
            {
                ModelState.AddModelError("", "Bu e-posta adresi ile zaten bir hesap mevcut.");
                return View(user);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await userservices.ValidateUserAsync(userLoginDto.Mail, userLoginDto.Passaword);
                if (user != null)
                {
                    HttpContext.Session.SetString("username", user.Name + " " + user.SurName);
                    HttpContext.Session.SetString("userId", user.ID.ToString());
                    return RedirectToAction("MainPage", "AnaSayfa");
                }
            }

            ModelState.AddModelError("", "Geçersiz giriş bilgileri.");
            return View();
        }

        [HttpGet]
        public IActionResult SifremiUnuttum()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SifremiUnuttum(string mail)
        {
            if(await userservices.CheckMail(mail) == true)
            {
                Random random = new Random();
                int randomNumber = random.Next(100000, 1000000);
                HttpContext.Session.SetInt32("VerificationCode", randomNumber);
                HttpContext.Session.SetString("Mail", mail);
                await emailSender.SendEmailAsync(mail, "sifre yenileme", randomNumber.ToString());
                
                return Redirect("Dogrulama");

            }
            else
            {
                ModelState.AddModelError("", "Bu e-posta adresiyle kayıtlı bir kullanıcı bulunmamaktadır.");
                return View();
            }
            
          
        }
        [HttpGet]
        public IActionResult Dogrulama()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Dogrulama(string confirmCode)
        {
            // Session'dan doğrulama kodunu alıyoruz
            var storedCode = HttpContext.Session.GetInt32("VerificationCode");

            if (storedCode.HasValue && storedCode.Value.ToString() == confirmCode)
            {
                // Kod doğru, şifre yenileme sayfasına yönlendiriyoruz
                return RedirectToAction("Sifreolustur");
            }
            else
            {
                // Kod yanlışsa hata mesajı
                ModelState.AddModelError("", "Doğrulama kodu yanlış.");
                return View();
            }
        }
        [HttpGet]
        public IActionResult Sifreolustur()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Sifreolustur([FromForm]string passaword)
        {
            // Kullanıcı mailini session'dan alıyoruz
            var userMail = HttpContext.Session.GetString("Mail");

            if (!string.IsNullOrEmpty(userMail))
            {
                // Kullanıcıyı email ile buluyoruz
                var user = await userservices.GetUserByEmailAsync(userMail);

                if (user != null)
                {
                    // Yeni şifreyi güncelliyoruz
                    user.Passaword = passaword;

                    // Kullanıcıyı güncelliyoruz
                    await userservices.UpdateUserAsync(user);

                    // Şifre başarıyla güncellendikten sonra session'ı temizliyoruz
                    HttpContext.Session.Remove("VerificationCode");
                    HttpContext.Session.Remove("UserMail");

                    // Başarılı olursa login sayfasına yönlendirin
                    return RedirectToAction("Login");
                }
            }

            // Kullanıcı veya session yoksa hata mesajı
            ModelState.AddModelError("", "Şifre yenileme başarısız oldu.");

            // Başarısız olursa tekrar şifre yenileme sayfasına dön
            return View();
        }


    }
}
