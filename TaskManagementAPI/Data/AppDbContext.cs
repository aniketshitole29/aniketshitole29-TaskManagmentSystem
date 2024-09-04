using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<UserTask> Tasks { get; set; }
        public DbSet<TaskNote> TaskNotes { get; set; }
        public DbSet<TaskDocument> TaskDocuments { get; set; }

        public DbSet<ApplicationUser> applicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call base OnModelCreating
            base.OnModelCreating(modelBuilder);

            // Hasher to hash the password before seeding the user to the DB
            var hasher = new PasswordHasher<IdentityUser>();

            // Seed ApplicationUser (make sure this is before IdentityUserRole)
            var adminUser = new ApplicationUser
            {
                Id = "8e445865-a24d-4543-a6c6-9443d048cd11",
                Email = "Admin@gmail.com",
                UserName = "Admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "Admin@123"),
                Name = "Admin",
                NormalizedUserName = "ADMIN@GMAIL.COM",
            };
            modelBuilder.Entity<ApplicationUser>().HasData(adminUser);

            // Seed IdentityRole
            var adminRole = new IdentityRole
            {
                Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                Name = "ADMIN",
                NormalizedName = "ADMIN"
            };
            modelBuilder.Entity<IdentityRole>().HasData(adminRole);

            // Seed IdentityUserRole (this should reference the above-seeded user and role)
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRole.Id,
                UserId = adminUser.Id
            });

            //modelBuilder.Entity<TaskNote>()
            //.HasOne(tn => tn.Task)
            //.WithMany(t => t.TaskNotes)
            //.HasForeignKey(tn => tn.TaskId);

            //modelBuilder.Entity<TaskDocument>()
            //    .HasOne(td => td.Task)
            //    .WithMany(t => t.TaskDocuments)
            //    .HasForeignKey(td => td.TaskId);
        }

    }
}
