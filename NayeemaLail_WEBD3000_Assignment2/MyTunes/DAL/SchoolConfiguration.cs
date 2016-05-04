using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace MyTunes.DAL
{

        public class SchoolConfiguration : DbConfiguration
        {
            public SchoolConfiguration()
            {
                SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            }
        }
    
}