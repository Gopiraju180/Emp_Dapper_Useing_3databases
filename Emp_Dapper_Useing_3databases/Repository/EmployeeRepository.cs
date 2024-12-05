using Dapper;
using Emp_Dapper_Useing_3databases.Entites;
using Emp_Dapper_Useing_3databases.Interface;
using Emp_Dapper_Useing_3databases.utils;
using System.Data;

namespace Emp_Dapper_Useing_3databases.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        IEmpConnectionFactory _connectionFactory;
        public EmployeeRepository(IEmpConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<int> AddEmployes(Employee empdetail)
        {
            using (IDbConnection con = _connectionFactory.hotelmanagementsqlConnectionString())
            {
                var p=new DynamicParameters();
                p.Add("@empname", empdetail.empname);
                p.Add("@empsalary", empdetail.empsalary);
                p.Add("@insertvalue", DbType.Int32, direction: ParameterDirection.Output);
                await con.ExecuteScalarAsync<int>(StoredProcedureNames.AddEmployee, p, commandType: CommandType.StoredProcedure);
                int insertedid = p.Get<int>("@insertvalue");
                return insertedid;
            }
        }

        public async Task<bool> DeleteEmployesById(int empid)
        {
            using(IDbConnection con= _connectionFactory.hotelmanagementsqlConnectionString())
            {
                var p=new DynamicParameters();
                p.Add("@empid", empid);
                await con.ExecuteScalarAsync(StoredProcedureNames.DeleteEmployee,p,commandType: CommandType.StoredProcedure);
                return true;
            }
        }

        public async Task<Employee> GetEmployeeById(int empid)
        {
            Employee emp;
           using(IDbConnection con = _connectionFactory.hotelmanagementsqlConnectionString())
            {
                var p= new DynamicParameters();
                p.Add("@empid", empid);
                var result= await con.QueryAsync<Employee>(StoredProcedureNames.GetEmployeeByEmpid,p,commandType: CommandType.StoredProcedure);
                emp=result.FirstOrDefault();
                return emp;
            }
        }

        public async Task<List<Employee>> GetEmployees()
        {
           List<Employee> res;
            using(IDbConnection con = _connectionFactory.hotelmanagementsqlConnectionString())
            {
                var queryList= await con.QueryAsync<Employee>(StoredProcedureNames.GetEmployee,commandType: CommandType.StoredProcedure);
                res= queryList.ToList();
                return res;
            }
        }

        public async Task<bool> UpdateEmploye(Employee empdetail)
        {
            using(IDbConnection con = _connectionFactory.hotelmanagementsqlConnectionString())
            {
                var p=new DynamicParameters();
                p.Add("@empid", empdetail.empid);
                p.Add("@empname", empdetail.empname);
                p.Add("@empsalary", empdetail.empsalary);
                await con.ExecuteReaderAsync(StoredProcedureNames.UpdateEmployee,p,commandType: CommandType.StoredProcedure);
                return true;
            }
        }
    }
}
