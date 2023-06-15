using System;
namespace KOS.Application.ViewModels.Content.Projects
{
	public class ProjectCreateRequest
	{
        public string Name { get; set; }


        public string Description { get; set; }


        public string? OwnerUserId { get; set; }

        public string? AvatarUrl { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
}

