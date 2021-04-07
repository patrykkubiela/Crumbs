using System;
using System.Collections.Generic;

namespace Crumbs.Core
{
    public interface ICrumb
    {
        Guid Uuid { get; }
        string Name { get; set; }
        string Description { get; set; }
        CrumbType Type { get; set; }
        
        IEnumerable<ICrumb> GetBranch();
        IEnumerable<ICrumb> GetWholeChain();
    }
}