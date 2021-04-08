using System;
using System.Collections.Generic;
using Crumbs.Core.Broadcasting;

namespace Crumbs.Core
{
    public interface ICrumb : IObserver, IBroadcast
    {
        Guid Uuid { get; }
        string Name { get; set; }
        string Description { get; set; }
        CrumbType Type { get; set; }
        ICrumb Broadcaster { get; set; }

        IEnumerable<ICrumb> GetBranch();
        IEnumerable<ICrumb> GetWholeChain();
    }
}