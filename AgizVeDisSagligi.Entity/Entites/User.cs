using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgizVeDisSagligi.Entity.Entites
{
    public class User
    {
        [Required]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Mail { get; set; }
        public int? ConfirmCode { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Passaword { get; set; }
        public ICollection<Goal>? Goals { get; set; }
    }
}
