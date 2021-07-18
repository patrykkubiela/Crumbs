using System;
using System.Collections.Generic;
using Crumbs.Shared;

namespace Crumbs.Data.Models
{
    public class Crumb
    {
        private Guid _uuid;

        public long Id { get; set; }

        public Guid Uuid
        {
            get => _uuid;
            set => _uuid = value != Guid.Empty ? value : Guid.NewGuid();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public CrumbType Type { get; set; }
        public long? BroadcasterId { get; set; }
        public virtual Crumb Broadcaster { get; set; }
        public virtual ICollection<Crumb> Observers { get; }
    }
}