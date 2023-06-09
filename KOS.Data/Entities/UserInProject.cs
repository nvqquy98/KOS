using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace KOS.Data.Entities
{
    [Table("UserInProjects")]

    public class UserInProject
    {

        public string UserId { get; set; }
        public string ProjectId { get; set; }
        public string RoleProjectId { get; set; }
    }
}

