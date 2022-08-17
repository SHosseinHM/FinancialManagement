using System.Collections.Specialized;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Repository.Connections
{
    public class ConnectionStrings
    {
        public static string FinancialManagmentConnection()
        {
            return "Server=.;Database=FinancialManagmentDB;Trusted_Connection=True";
        }
    }
}