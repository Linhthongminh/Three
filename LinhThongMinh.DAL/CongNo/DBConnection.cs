using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhThongMinh.DAL.CongNo
{
    public class DBConnection
    {
        public DBConnection()
        {

        }
        public SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source =DESKTOP-T2KI0HE\MAYAO; Initial CataLog = QLBH; User Id = sa; Password = 123";
            return conn;

        }
    }
}
