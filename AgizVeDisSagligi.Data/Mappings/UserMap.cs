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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            Random random = new Random();
            builder.HasData(
                
                new User
                {
                    ID = Guid.Parse("F5561E30-BC35-49B9-8862-9F05E9BB7A0E"),
                    Name = "asp.core",
                    SurName = "ben",
                    BirthDate = DateOnly.Parse("2000-10-01"),
                    Mail = "false",
                    Passaword = "123",
                    ConfirmCode = random.Next(10000,100000)
                    

                },
                new User
                {
                    ID = Guid.Parse("747BCE62-6F05-4B49-BEEC-56FEB6F18A6B"),
                    Name = "aasdre",
                    SurName = "sen",
                    BirthDate = DateOnly.Parse("2020-10-01"),
                    Mail = "false",
                    Passaword = "123",
                    ConfirmCode = random.Next(10000, 100000)

                });
        }
    }
}
