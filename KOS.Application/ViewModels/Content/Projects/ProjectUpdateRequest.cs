using System;
namespace KOS.Application.ViewModels.Content.Projects
{
	public class ProjectUpdateRequest
	{
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string? AvatarUrl { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
}

