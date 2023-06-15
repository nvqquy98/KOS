using System;
namespace KOS.Application.ViewModels.Content.Sprint
{
	public class SprintCreateRequest
	{
        public int? BoardId { get; set; }

        public string? Name { get; set; }


        public string? Description { get; set; }


        public bool IsActive { get; set; }
        public string? StartUserId { get; set; }
        
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}

