using System;
using KOS.Application.ViewModels.Common;

namespace KOS.Application.ViewModels.Content.Projects
{
	public class GetProjectPagingRequest : PagingRequestBase
    {
        public string? Keyword { get; set; }
        
    }
}

