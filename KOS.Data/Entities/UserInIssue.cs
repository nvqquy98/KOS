using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOS.Data.Entities
{
    [Table("UserInIssues")]

    public class UserInIssue
    {
        public  string UserId { get; set; }
        public  string SprintId { get; set; }
        public  string IssueId { get; set; }
    }
}
