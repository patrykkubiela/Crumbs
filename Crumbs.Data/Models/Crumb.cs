using System;
using System.Collections.Generic;
using Crumbs.Shared;

namespace Crumbs.Data.Models
{
    public class Crumb
    {
        public Guid Uuid { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CrumbType Type { get; set; }
        public Crumb Broadcaster { get; set; }
        public ICollection<Crumb> Observers { get; }
    }
}