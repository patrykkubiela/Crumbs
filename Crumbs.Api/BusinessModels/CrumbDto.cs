using System;
using System.Collections.Generic;
using Crumbs.Shared;

namespace Crumbs.Api.BusinessModels
{
    public class CrumbDto
    {
        public CrumbDto(Guid uuid, IEnumerable<CrumbDto> observers = null)
        {
            Uuid = uuid;

            if (observers != null)
                Observers = new List<CrumbDto>(observers);
        }

        public Guid Uuid { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CrumbType Type { get; set; }
        public virtual ICollection<CrumbDto> Observers { get; }
    }
}