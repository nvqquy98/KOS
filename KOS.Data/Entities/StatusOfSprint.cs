using KOS.Data.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KOS.Data.Enums;

namespace KOS.Data.Entities
{   
    [Table("StatusOfSprints")]
    public class StatusOfSprint : IDateTracking
    {
            [Key]
            public string? Id { get; set; }

            [MaxLength(50)]
            [Column(TypeName = "varchar(50)")]
            [Required]
            public string? ProjectId { get; set; }

            [MaxLength(500)]
            public string? Name { get; set; }

            public string? Description { get; set; }

            public int? Limit { get; set; }

            public int ListPosition { get; set; }



        public DateTime CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
    
}
