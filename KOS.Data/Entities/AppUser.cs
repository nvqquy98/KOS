using KOS.Data.Enums;
using KOS.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOS.Data.Entities
{
    [Table("AppUsers")]
    public class AppUser : IdentityUser<string>, IDateTracking, ISwitchable
    {
        public AppUser()
        {
        }

        public AppUser(string id, string userName, string firstName, string lastName,
            string email, string phoneNumber, DateTime dob, string avatarUrl)
        {
            Id = id;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Dob = dob;
            AvatarUrl = avatarUrl;
        }
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        public string AvatarUrl { get; set; }
        [Required]
        public DateTime Dob { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public Status Status { get; set; }
    }
}
