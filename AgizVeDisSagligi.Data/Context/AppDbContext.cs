using AgizVeDisSagligi.Data.Mappings;
using AgizVeDisSagligi.Entity.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AgizVeDisSagligi.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Situation> Situations { get; set; }
        public DbSet <Suggestion> Suggestions { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ValidationMap());
            

            // User - Goal ilişkisi
            base.OnModelCreating(builder);

            // User - Goal ilişkisi
            builder.Entity<Goal>()
                .HasOne(g => g.User)
                .WithMany(u => u.Goals)
                .HasForeignKey(g => g.UserId)
                .OnDelete(DeleteBehavior.Restrict); 

            
            builder.Entity<Situation>()
                .HasOne(s => s.Goal)
                .WithMany(g => g.Situationes) 
                .HasForeignKey(s => s.GoalId)
                .OnDelete(DeleteBehavior.Cascade); 

            base.OnModelCreating(builder);



        }
    }
}
