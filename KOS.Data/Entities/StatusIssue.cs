using KOS.Data.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using KOS.Infrastructure.SharedKernel;

namespace KOS.Data.Entities
{   
    [Table("StatusIssues")]
    public class StatusIssue : DomainEntity<int>, IDateTracking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[MaxLength(50)]
        //[Column(TypeName = "varchar(50)")]
        //[Required]
        //public string? ProjectId { get; set; }

        [MaxLength(500)]
        public string? Name { get; set; }

        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
    
}
