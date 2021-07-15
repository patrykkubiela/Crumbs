using System;
using System.Collections.Generic;
using Crumbs.Shared;

namespace Crumbs.Data.Models
{
    public class Crumb
    {
        public Crumb()
        {
            Uuid = Uuid != Guid.Empty ? Uuid : Guid.NewGuid();
        }

        public long Id { get; set; }
        public Guid Uuid { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CrumbType Type { get; set; }

        public long? BroadcasterId { get; set; }
        public virtual Crumb Broadcaster { get; set; }
        public virtual ICollection<Crumb> Observers { get; }
    }
}