using System.Collections.Generic;

namespace Crumbs.Core
{
    public interface IBroadcast
    {
        List<IObserve> Observers { get; }
        
        void RegisterObserver(IObserve observer);
        void UnregisterObserver(IObserve observer);
        void Broadcast();
    }
}