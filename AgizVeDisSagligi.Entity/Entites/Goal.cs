using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgizVeDisSagligi.Entity.Entites
{
    public class Goal
    {
        public Guid Id { get; set; }
        public DateOnly CreatedDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public string Title { get; set; }
        public string Description { get; set; }
        public string Periot { get; set; }
        public string PeriotLevel { get; set; }
        public int Frequency { get; set; }
        public string? HedefAdi { get; set; }
        public ICollection<Situation>? Situationes { get; set; }  // Bir hedefe ait resimlerin koleksiyonu
        public Guid UserId { get; set; }
        public User User { get; set; }
        
    }
}
