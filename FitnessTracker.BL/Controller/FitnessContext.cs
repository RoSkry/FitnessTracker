using FitnessTracker.BL.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FitnessTracker.BL.Controller
{
    public class FitnessContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Eating> Eatings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-190EJV1;Database=FitnessTracker;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Eating>(e =>
            {
                e.Property(p => p.Foods).HasConversion(
                    d => JsonConvert.SerializeObject(d, Formatting.None),
                    s => JsonConvert.DeserializeObject<Dictionary<Food, double>>(s)
                    );
            }
                );
        }
    }
}
