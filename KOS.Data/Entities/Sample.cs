using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KOS.Data.Interfaces;
using KOS.Infrastructure.SharedKernel;

namespace KOS.Data.Entities
{
    [Table("Samples")]

    public class Sample :   DomainEntity<int>, IDateTracking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

		public string Name { get; set; }
		public int SortOrder { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}

