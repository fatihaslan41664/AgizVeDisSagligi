using AgizVeDisSagligi.Data.UnitOfWorks;
using AgizVeDisSagligi.Entity.DTOs;
using AgizVeDisSagligi.Entity.Entites;
using AgizVeDisSagligi.Services.Services.Abstraction;
using AgizVeDisSagligi.Services.Services.Concrates;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace AgizVeDisSagligi.Web.Controllers
{
    public class AgizVeDisController : Controller
    {
        private readonly ILogger<LoginRegisterController> _logger;
        private readonly IUserServices services;
        private readonly IGoalservices goalservices;
        private readonly ISituationService situationservice;
        

        public AgizVeDisController(IUserServices services, IGoalservices goalservices, ISituationService situationservice)
        {
            this.services = services;
            this.goalservices = goalservices;
            this.situationservice = situationservice;
            
        }
        [HttpGet]
        public async Task<IActionResult> AgizVeDisSagligi()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddGoal()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGoal(AddGoalDto addgoalDto)
        {
            // Kullanıcının kimlik Id'sini Session'dan alıyoruz
            var id = HttpContext.Session.GetString("userId");

            
            // Eğer session'da userId bulunamazsa, hata mesajı verelim
            if (string.IsNullOrEmpty(id))
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı bilgisi bulunamadı.");
                return View(addgoalDto);
            }

            // UserId'yi DTO'ya ekliyoruz
            addgoalDto.UserId = Guid.Parse(id);

            // Veritabanına eklemek için servisi çağırıyoruz
            bool result = await goalservices.CreateGoalAsync(addgoalDto);
           
            // Eğer işlem başarılı olduysa
            if (result)
            {
                // Başarılı bir işlem sonrası başka bir sayfaya yönlendirebilirsiniz (Örn: Başarı sayfası)
                return RedirectToAction("AgizVeDisSagligi");
            }

            // İşlem başarısız olduysa formu tekrar göster
            ModelState.AddModelError(string.Empty, "Hedef eklenirken bir hata oluştu.");
            return View(addgoalDto);
        }
        [HttpGet]
        public async Task<IActionResult> Situation()
        {
            var id = HttpContext.Session.GetString("userId");
            Guid userId = Guid.Parse(id);
            var sit = await situationservice.GetSituationByUserIdAsync(userId);
            return View(sit);

        }
        [HttpGet]
        public async Task<IActionResult> AddSituation()
        {
            var id = HttpContext.Session.GetString("userId");

            Guid userId = Guid.Parse(id);
            var sit = await goalservices.GetGoalsByUserIdAsync(userId);

            
            //ViewBag.Goals = new SelectList(sit, "Id", "HedefAdi");
            
            return View(sit);
        }
        
        [HttpGet]
        public async Task<IActionResult> AddSituationToGoal(Guid goalId)
        {
            var goal = await goalservices.GetGoalsByUserIdAsync(goalId);
            if (goal == null)
            {
                return NotFound();
            }

            // Kullanıcıya göstermek için hedef bilgisi veya boş bir AddSituationDto oluşturun
            var model = new AddSituationDto
            {
                GoalId = goalId // Seçilen hedefin ID'si
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddSituationToGoal(AddSituationDto model, IFormFile file)
        {
            var id = HttpContext.Session.GetString("userId");
            if (string.IsNullOrEmpty(id))
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı bilgisi bulunamadı.");
                return View(model);
            }

            model.UserId = Guid.Parse(id);

            // Dosya boş değilse kaydet
            if (file != null && file.Length > 0)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                model.ImageUrl = String.Concat("/images/", file.FileName);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Lütfen bir resim dosyası yükleyin.");
                return View(model);
            }

            // Durumu ekle
            var result = await situationservice.AddStatuAsync(model);

            if (result)
            {
                return RedirectToAction("Situation");
            }

            ModelState.AddModelError(string.Empty, "Durum eklenirken bir hata oluştu.");
            return View(model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            
            await situationservice.DeleteAsync(id);
            return RedirectToAction("Situation");
        }
        public async Task<IActionResult> GoalDeleter(Guid id)
        {

            await goalservices.DeleteAsync(id);
            return RedirectToAction("AgizVeDisSagligi");
        }

    }
}
