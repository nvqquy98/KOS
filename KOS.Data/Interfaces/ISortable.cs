using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOS.Data.Interfaces
{
    public interface ISortable
    {
        int SortOrder { set; get; }
    }
}
