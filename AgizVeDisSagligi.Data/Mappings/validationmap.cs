using AgizVeDisSagligi.Entity.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgizVeDisSagligi.Data.Mappings
{
    internal class ValidationMap : IEntityTypeConfiguration<Suggestion>
    {
        public void Configure(EntityTypeBuilder<Suggestion> builder)
        {
            builder.HasData(
                new Suggestion
                {
                    ID = 1,
                    Recommendation = "Diş hekiminizi yılda en az iki kez ziyaret edin."

                },
                new Suggestion
                {
                    ID = 2,
                    Recommendation = "Diş çürümelerini önlemek için florürlü diş macunu kullanın."
                },
                new Suggestion
                {
                    ID = 3,
                    Recommendation = "Alkol, ağız kuruluğuna neden olabilir; bu nedenle tüketimini sınırlayın."
                },
                new Suggestion
                {
                    ID = 4,
                    Recommendation = " Şekerli ve asitli yiyeceklerden uzak durarak dengeli bir diyet uygulayın."
                },
                new Suggestion
                {
                    ID = 5,
                    Recommendation = "Diş sağlığınızı takip etmek için uygulamalar veya günlükler kullanarak alışkanlıklarınızı gözlemleyin."
                },
                new Suggestion
                {
                    ID = 6,
                    Recommendation = "Dişlerinizin arasındaki yiyecekleri temizlemek için günde bir kez diş ipi kullanın."
                },
                new Suggestion
                {
                    ID = 7,
                    Recommendation = "Antiseptik ağız gargarası kullanarak ağız hijyeninizi artırın."
                },
                new Suggestion
                {
                    ID = 8,
                    Recommendation = "Gazlı içecekler ve meyve suları gibi asidik içecekleri sınırlayın."
                }
            );
        }
    }
}
