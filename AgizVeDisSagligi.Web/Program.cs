using AgizVeDisSagligi.Data.Extentions;
using AgizVeDisSagligi.Services.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Data ve Service layer extension metodlar�n� �a��r�yoruz
builder.Services.LoadDataLayerExtention(builder.Configuration);
builder.Services.LoadServiceLayerExtention();

// AutoMapper servisini ekleyelim
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Session ayarlar�
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Di�er middleware ve servisler
var app = builder.Build();

// Hata y�netimi ve pipeline ayarlar�
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Session ve yetkilendirme middleware'leri
app.UseSession();
app.UseAuthorization();

// Default route ayarlar�
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
