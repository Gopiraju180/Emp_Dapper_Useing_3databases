using Dapper;
using Emp_Dapper_Useing_3databases.Entites;
using Emp_Dapper_Useing_3databases.Interface;
using Emp_Dapper_Useing_3databases.utils;
using System.Data;

namespace Emp_Dapper_Useing_3databases.Repository
{
    public class DepartementRepository : IDepartmentRepository
    {
        IEmpConnectionFactory _connectionFactory;
        public DepartementRepository(IEmpConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory; 
        }
        public async Task<int> AddDeparment(Departement deptdetail)
        {
            using (IDbConnection con = _connectionFactory.Northwind_DBSqlConnectionString())
            {
                //create object for storedprocedure input values binding purpose
                var p =new DynamicParameters();//DynamicParameters Are Commming From Dapper Package
                p.Add("@deptname", deptdetail .deptname);
                p.Add("@deptlocation",deptdetail.deptlocation);
                p.Add("@insertedvalue", DbType.Int32, direction: ParameterDirection.Output);
                await con.ExecuteScalarAsync<int>(StoredProcedureNames.AddDepartment, p, commandType: CommandType.StoredProcedure);
                int inserterdid = p.Get<int>("@insertedvalue");
                return inserterdid;
            }
        }

        public async Task<bool> DeleteDepartmentById(int deptid)
        {
            using (IDbConnection con = _connectionFactory.Northwind_DBSqlConnectionString())
            {
                var p=new DynamicParameters();
                p.Add("@deptid",deptid);
                await con.ExecuteScalarAsync(StoredProcedureNames.DeleteDepartment,p,commandType:CommandType.StoredProcedure);
                return true;
            }
        }

        public async Task<List<Departement>> GetDepartMentDetails()
        {
            List<Departement> res;
            using (IDbConnection con = _connectionFactory.Northwind_DBSqlConnectionString())
            {
                var queryList = await con.QueryAsync<Departement>(StoredProcedureNames.GetDepartment, commandType: CommandType.StoredProcedure);
                res = queryList.ToList();
                return res;
            }
        }

        public async Task<Departement> GetDepartmentDetailsById(int deptid)
        {
            Departement dpt;
            using(IDbConnection con = _connectionFactory.Northwind_DBSqlConnectionString())
            {
                var p=new DynamicParameters();
                p.Add("@deptid", deptid);
                var result= await con.QueryAsync<Departement>(StoredProcedureNames.GetDepartmentByDeptId,p,commandType:CommandType.StoredProcedure);
                dpt = result.FirstOrDefault();
                return dpt;
            }
        }

        public async Task<bool> UpdateDepartment(Departement deptdetail)
        {
           using(IDbConnection con=_connectionFactory.Northwind_DBSqlConnectionString())
            {
                var p=new DynamicParameters();
                p.Add("@deptid", deptdetail.deptid);
                p.Add("@deptname", deptdetail.deptname);
                p.Add("@deptlocation", deptdetail.deptlocation);
                await con.ExecuteReaderAsync(StoredProcedureNames.UpdateDepartment,p,commandType:CommandType.StoredProcedure);
                return true;
            }
        }
    }
}
