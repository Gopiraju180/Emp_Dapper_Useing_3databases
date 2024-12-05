using System.Data;

namespace Emp_Dapper_Useing_3databases.Interface
{
    public interface IEmpConnectionFactory
    {
        IDbConnection Northwind_DBSqlConnectionString();
        IDbConnection hotelmanagementsqlConnectionString();
        IDbConnection MidLandSqlConnectionString();
    }
}
