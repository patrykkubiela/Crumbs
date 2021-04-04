using System.Collections.Generic;
using Crumbs.Core.Broadcasting;

namespace Crumbs.Core
{
    public abstract class CrumbBase: IObserver, IBroadcast
    {
        public List<IObserver> Observers { get; }

        public CrumbBase()
        {
            Observers = new List<IObserver>();
        }

        public abstract void Receive();

        public virtual void RegisterObserver(IObserver observer)
        {
            Observers.Add(observer);
        }

        public virtual void UnregisterObserver(IObserver observer)
        {
            Observers.Remove(observer);
        }

        public virtual void Broadcast()
        {
            Observers.ForEach(o => o.Receive());
        }
    }
}