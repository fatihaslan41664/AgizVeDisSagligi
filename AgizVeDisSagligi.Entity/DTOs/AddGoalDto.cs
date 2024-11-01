using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgizVeDisSagligi.Entity.DTOs
{
    public class AddGoalDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Periot { get; set; }
        public int Frequency { get; set; }
        public string PeriotLevel { get; set; }
    }
}
