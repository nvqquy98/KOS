using KOS.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOS.Data.Entities
{
    [Table("Comments")]

    public class Comment : IDateTracking
    {
        [Key]
        public string Id { get; set; }

        [MaxLength(500)]
        [Required]
        public string Body { get; set; }

        [Required]
        [Range(1, Double.PositiveInfinity)]
        public string IssueId { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string UserId { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
