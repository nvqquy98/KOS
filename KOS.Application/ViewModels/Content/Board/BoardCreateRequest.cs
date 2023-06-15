using System;
namespace KOS.Application.ViewModels.Content.Board
{
	public class BoardCreateRequest
	{
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string ProjectId { get; set; }
        public bool IsKanban { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}


