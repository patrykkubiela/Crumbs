using System;
using System.Collections.Generic;
using Crumbs.Core.Broadcasting;

namespace Crumbs.Core
{
    public abstract class CrumbBase: IObserver, IBroadcast, ICrumb
    {
        public Guid Uuid { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CrumbType Type { get; set; }
        public List<IObserver> Observers { get; }


        protected CrumbBase()
        {
            Uuid = Guid.NewGuid();
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

        public IEnumerable<ICrumb> GetBranch()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICrumb> GetWholeChain()
        {
            throw new NotImplementedException();
        }
    }
}