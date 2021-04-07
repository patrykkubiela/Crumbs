using System;
using System.Collections.Generic;
using Crumbs.Core.Broadcasting;

namespace Crumbs.Core
{
    public abstract class CrumbBase : ICrumb
    {
        public Guid Uuid { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CrumbType Type { get; set; }
        public List<ICrumb> Observers { get; }


        protected CrumbBase()
        {
            Uuid = Guid.NewGuid();
            Observers = new List<ICrumb>();
        }

        public abstract void Receive();


        public virtual void RegisterObserver(ICrumb observer)
        {
            Observers.Add(observer);
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
            var result = new List<ICrumb>();
            result.Add(this);

            Observers.ForEach(o => result.Add(o));

            return result;
        }

        public IEnumerable<ICrumb> GetWholeChain()
        {
            throw new NotImplementedException();
        }
    }
}