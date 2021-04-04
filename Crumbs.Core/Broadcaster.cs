using System.Collections.Generic;

namespace Crumbs.Core
{
    public class Broadcaster : IBroadcast
    {
        public List<IObserve> Observers { get; private set; }

        public Broadcaster()
        {
            Observers = new List<IObserve>();
        }
        
        public void RegisterObserver(IObserve observer)
        {
            Observers.Add(observer);
        }

        public void UnregisterObserver(IObserve observer)
        {
            Observers.Remove(observer);
        }

        public void Broadcast()
        {
            Observers.ForEach(ob => ob.Receive());
        }
    }
}