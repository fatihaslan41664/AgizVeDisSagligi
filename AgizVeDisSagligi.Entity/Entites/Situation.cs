using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgizVeDisSagligi.Entity.Entites
{
    public class Situation
    {
        public Guid SituationID { get; set; }
        public string SituationName { get; set; }
        public string HedefAdi { get; set; }
        
        public String? ImageUrl { get; set; }
        public Goal? Goal { get; set; }
        public Guid? GoalId { get; set; }
        public User User { get; set; } 
        public Guid UserId {  get; set; }
        public DateOnly CreatedDate {  get; set; } = DateOnly.FromDateTime(DateTime.Now);

    }
}
