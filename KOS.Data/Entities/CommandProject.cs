using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace KOS.Data.Entities
{
    [Table("CommandProjects")]
    public class CommandProject
	{
		public int RoleProjectId { get; set; }
        public int SampleId { get; set; }
        public int StatusId { get; set; }

    }
}

