using System;
using System.Collections.Generic;
using Crumbs.Shared;

namespace Crumbs.Api.BusinessModels
{
    public class CrumbDto
    {
        public CrumbDto(Guid uuid)
        {
            Uuid = uuid;
        }

        public Guid Uuid { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CrumbType Type { get; set; }
        public virtual IEnumerable<CrumbDto> Observers { get; set; }
    }
}