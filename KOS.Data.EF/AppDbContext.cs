using KOS.Data.Entities;
using KOS.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

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

           

            builder.Entity<UpdateProject>()
                       .HasKey(c => new { c.RoleProjectId, c.StatusId, c.SampleId });

          

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

        public DbSet<Issue> Issues { set; get; }

        public DbSet<RoleProject> RoleProjects { set; get; }
        public DbSet<Project> Projects { set; get; }
        public DbSet<Sprint> Sprints { set; get; }
        public DbSet<StatusIssue> StatusIssues { set; get; }
        public DbSet<UpdateProject> UpdateProjects { set; get; }

        public DbSet<UserInProject> UserInProjects { set; get; }

        

    }
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var hostBuilder = new HostBuilder()
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    var env = hostContext.HostingEnvironment;
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("appsettings.json");
                })
                .Build();

            var configuration = hostBuilder.Services.GetService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            dbContextOptionsBuilder.UseSqlServer(connectionString);

            return new AppDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
