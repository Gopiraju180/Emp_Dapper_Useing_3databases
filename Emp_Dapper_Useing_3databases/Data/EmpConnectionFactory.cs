using Emp_Dapper_Useing_3databases.Interface;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Emp_Dapper_Useing_3databases
{
    public class EmpConnectionFactory : IEmpConnectionFactory
    {
        private readonly IConfiguration _config;
        public EmpConnectionFactory(IConfiguration config)
        {
            _config = config; 
        }
        public IDbConnection Northwind_DBSqlConnectionString()
        {
            var connStr = Convert.ToString(_config.GetSection("ConnectionStrings:Northwind_DBSqlConnectionString").Value);
            IDbConnection con=new SqlConnection(connStr);
            return con;
        }
        public IDbConnection hotelmanagementsqlConnectionString()
        {
            var connStr = Convert.ToString(_config.GetSection("ConnectionStrings:hotelmanagementsqlConnectionString").Value);
            IDbConnection con = new SqlConnection(connStr);
            return con;
        }
        public IDbConnection MidLandSqlConnectionString()
        {
            var connStr = Convert.ToString(_config.GetSection("ConnectionStrings:MidLandSqlConnectionString").Value);
            IDbConnection con = new SqlConnection(connStr);
            return con;
        }
    }
}
