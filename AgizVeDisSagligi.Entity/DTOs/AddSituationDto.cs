using AgizVeDisSagligi.Entity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgizVeDisSagligi.Entity.DTOs
{
    public class AddSituationDto
    {
        public Guid SituationID { get; set; }
        public string SituationName { get; set; }
        public string HedefAdi { get; set; }



        public User User { get; set; }
        public Guid UserId { get; set; }
        public Goal? Goal { get; set; }
        public Guid? GoalId { get; set; }
        
        
        public String? ImageUrl { get; set; }
    }
}
