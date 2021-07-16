using System.Collections.Generic;
using System.Linq;
using Crumbs.Api.BusinessModels;
using Crumbs.Data.Models;

namespace Crumbs.Api
{
    public static class CrumbsConverter
    {
        public static IEnumerable<CrumbDto> ConvertToDtos(this IEnumerable<Crumb> crumbs)
        {
            return crumbs.Select(c => c.ConvertToDto());
        }
        
        public static CrumbDto ConvertToDto(this Crumb crumb)
        {
            return new CrumbDto(crumb.Uuid)
            {
                Name = crumb.Name,
                Description = crumb.Description,
                Type = crumb.Type
            };
        }
    }
}