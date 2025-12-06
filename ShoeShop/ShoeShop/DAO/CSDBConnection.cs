using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop.DAO
{
    public class CSDBConnection
    {
        public SqlConnection Connection()
        {
			string connectionString = ConfigurationManager.ConnectionStrings["ShopBanGiay"].ConnectionString;
			return new SqlConnection(connectionString);
        }
    }
}
