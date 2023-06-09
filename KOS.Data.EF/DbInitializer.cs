using KOS.Data.Entities;
using KOS.Data.Enums;
using KOS.Utilities.Constants;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOS.Data.EF
{
    public class DbInitializer
    {
        private readonly AppDbContext _context;
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;
        public DbInitializer(AppDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Description = "Top manager"
                });
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Dev",
                    NormalizedName = "Dev",
                    Description = "Dev"
                });
               
            }
            if (!_userManager.Users.Any())
            {
                await _userManager.CreateAsync(new AppUser(Guid.NewGuid().ToString(),"admin", "admin", "app", "adminKOS123@gmail.com", "0123456789", DateTime.Now, "" )
                , "123654$");
                var user = await _userManager.FindByNameAsync("admin");
                await _userManager.AddToRoleAsync(user, "Admin");
            }                                                                                       
            await _context.SaveChangesAsync();

        }
    }
}
