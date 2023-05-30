using KOS.Data.Entities;
using KOS.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace KOS.Data.EF
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, String>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().Property(x => x.Id).HasMaxLength(50).IsUnicode(false);
            builder.Entity<AppUser>().Property(x => x.Id).HasMaxLength(50).IsUnicode(false);

           

            builder.Entity<Permission>()
                       .HasKey(c => new { c.RoleId, c.FunctionId });

            builder.Entity<UserInIssue>()
                        .HasKey(c => new { c.UserId, c.IssueId });

            builder.Entity<UserInProject>()
                       .HasKey(c => new { c.UserId, c.ProjectId });
           

            builder.HasSequence("KOSAppSequence");
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        public DbSet<ActivityLog> ActivityLogs { set; get; }
        public DbSet<Board> Boards { set; get; }

        public DbSet<Comment> Comments { set; get; }

        public DbSet<Function> Functions { set; get; }
        public DbSet<Issue> Issues { set; get; }

        public DbSet<Permission> Permissions { set; get; }
        public DbSet<Project> Projects { set; get; }
        public DbSet<Sprint> Sprints { set; get; }
        public DbSet<StatusOfSprint> StatusOfSprints { set; get; }

        public DbSet<UserInIssue> UserInIssues { set; get; }
        public DbSet<UserInProject> UserInProjects { set; get; }



    }
}
