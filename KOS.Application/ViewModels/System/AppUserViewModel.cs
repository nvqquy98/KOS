using System;
using KOS.Data.Enums;

namespace KOS.Application.ViewModels.System
{
    public class AppUserViewModel
    {
        public AppUserViewModel()
        {
            Roles = new List<string>();
        }
        public string Id { get; set; }
        public string FirstName { set; get; }

        public string LastName { set; get; }
        public string Dob { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string UserName { set; get; }
        public string Address { get; set; }
        public string PhoneNumber { set; get; }
        public Status Status { set; get; }

        public string AvatarUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public List<string> Roles { get; set; }
    }
}
