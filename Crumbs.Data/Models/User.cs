using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Crumbs.Data.Models
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }
        
        public virtual ICollection<Crumb> Crumbs { get; set; }
    }
}