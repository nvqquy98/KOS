using KOS.Data.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KOS.Infrastructure.SharedKernel;

namespace KOS.Data.Entities
{
    public class Sprint : DomainEntity<int>, IDateTracking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        public int? BoardId { get; set; }

        public string? Name { get; set; }

        [MaxLength(500)]
        [Required]
        public string? Description { get; set; }

        //[Required]
        //[MaxLength(50)]
        //[Column(TypeName = "varchar(50)")]
        //public string OwnerUserId { get; set; }

        //public string AvatarUrl { get; set; }
        public bool IsActive { get; set; }
        public string? StartUserId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }


        public DateTime CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
