using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Nyoba
{
    class Koneksi
    {
        public SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection(

                "Data Source = KIDDY\\CCITFTUI;" +
                "Initial Catalog = CCITFTUI;" +
                "User Id = sa; Password = 123456"
             );
            return con;
        }
    }
}
