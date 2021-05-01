using System.Collections.Generic;

namespace Crumbs.Core.Broadcasting
{
    public interface IBroadcast
    {
        List<ICrumb> Observers { get; }
        
        void RegisterObserver(ICrumb observer);
        void UnregisterObserver(ICrumb observer);
        void Broadcast();
    }
}