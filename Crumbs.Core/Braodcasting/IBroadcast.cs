using System.Collections.Generic;

namespace Crumbs.Core.Broadcasting
{
    public interface IBroadcast
    {
        List<IObserver> Observers { get; }
        
        void RegisterObserver(IObserver observer);
        void UnregisterObserver(IObserver observer);
        void Broadcast();
    }
}