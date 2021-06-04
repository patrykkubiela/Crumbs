using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Crumbs.Data.Models;
using Dapper;

namespace Crumbs.Data.Repositories
{
    public class CrumbsRepository : ICrumbsRepository
    {
        public ICollection<Crumb> GetCrumbs(string query)
        {
            using var connection = PostgresDbConnectionProvider.GetDbConnection();
            connection.UserCertificateValidationCallback = UserCertificateValidationCallback;
            var events = connection.Query<Crumb>(query).ToList();
            return events;
        }

        private bool UserCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslpolicyerrors)
        {
            return true;
        }
    }
}
