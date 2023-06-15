using System;
namespace KOS.Application.ViewModels.Content.Sprint
{
	public class SprintUpdateRequest
	{
        public int? BoardId { get; set; }

        public string? Name { get; set; }


        public string? Description { get; set; }


        public bool IsActive { get; set; }
        public string? StartUserId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }


        public DateTime CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}

