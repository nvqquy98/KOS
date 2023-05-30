using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOS.Data.Entities
{
    [Table("UserInProjects")]

    public class UserInProject
    {
        public string UserId { get; set; }
        public string ProjectId { get; set; }
    }
}
