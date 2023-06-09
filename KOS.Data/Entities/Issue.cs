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
    [Table("Issues")]
    public class Issue : IDateTracking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
      
        public int StatusId { get; set; }

        public int SampleId { get; set; }

        public int SprintId { get; set; }

        public string AssignId { get; set; }

        public string ReporterId { get; set; }

        [MaxLength(500)]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Priority { get; set; }

        public int Estimate { get; set; }

        public int TimeSpent { get; set; }
        public int TimeRemaining { get; set; }

        public int ListPosition { get; set; }

        public string Labels { get; set; }

        public int? NumberOfComments { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreateDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
}
