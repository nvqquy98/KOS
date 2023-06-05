using System;
namespace KOS.Application.ViewModels.System
{
	public class UserCreateRequest
	{
        public UserCreateRequest()
        {
            Roles = new List<string>();
        }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string Dob { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
        public string AvatarUrl { get; set; }
        public List<string> Roles { get; set; }



    }
}

