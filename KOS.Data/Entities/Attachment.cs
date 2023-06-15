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
    [Table("Attachments")]
    public class Attachment : DomainEntity<int>, IDateTracking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string? FileName { get; set; }

        [Required]
        [MaxLength(200)]
        public string? FilePath { get; set; }

        [Required]
        [MaxLength(6)]
        [Column(TypeName = "varchar(6)")]
        public string? FileType { get; set; }

        [Required]
        public long FileSize { get; set; }

        public string? IssueId { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
