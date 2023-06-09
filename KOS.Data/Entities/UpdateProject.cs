using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace KOS.Data.Entities
{
    [Table("UpdateProject")]
    public class UpdateProject
    {
		public int RoleProjectId { get; set; }
        public int SampleId { get; set; }
        public int StatusId { get; set; }       
    }
}

