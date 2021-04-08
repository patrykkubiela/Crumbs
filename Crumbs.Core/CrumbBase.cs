using System;
using System.Collections.Generic;

namespace Crumbs.Core
{
    public abstract class CrumbBase : ICrumb
    {
        public Guid Uuid { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CrumbType Type { get; set; }
        public ICrumb Broadcaster { get; set; }
        public List<ICrumb> Observers { get; }


        protected CrumbBase()
        {
            Uuid = Guid.NewGuid();
            Observers = new List<ICrumb>();

            // Receive<Crumb>(RegisterObserver);
        }

        public abstract void Receive();


        public virtual void RegisterObserver(ICrumb observer)
        {
            Observers.Add(observer);
            observer.Broadcaster = this;
        }

        public virtual void UnregisterObserver(ICrumb observer)
        {
            Observers.Remove(observer);
        }

        public virtual void Broadcast()
        {
            Observers.ForEach(o => o.Receive());
        }

        public IEnumerable<ICrumb> GetBranch()
        {
            return Branch();
        }

        public IEnumerable<ICrumb> GetWholeChain()
        {
            var result = new List<ICrumb>();
            result.AddRange(Branch());
            result.AddRange(Chain());
            return result;
        }

        private IEnumerable<ICrumb> GetObservers(IEnumerable<ICrumb> observers)
        {
            var result = new List<ICrumb>();

            foreach (var observer in observers)
            {
                result.Add(observer);
                result.AddRange(GetObservers(observer.Observers));
            }

            return result;
        }

        private IEnumerable<ICrumb> Chain()
        {
            return GetBroadcasters(this);
        }

        private IEnumerable<ICrumb> GetBroadcasters(ICrumb observer)
        {
            var result = new List<ICrumb>();
            if (observer?.Broadcaster != null)
            {
                result.Add(observer.Broadcaster);
                result.AddRange(GetBroadcasters(observer.Broadcaster));
            }

            return result;
        }

        private IEnumerable<ICrumb> Branch()
        {
            var result = new List<ICrumb>();
            result.Add(this);
            result.AddRange(GetObservers(Observers));
            return result;
        }
    }
}