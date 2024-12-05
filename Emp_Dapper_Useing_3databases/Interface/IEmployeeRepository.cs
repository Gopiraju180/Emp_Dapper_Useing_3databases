using Emp_Dapper_Useing_3databases.Entites;

namespace Emp_Dapper_Useing_3databases.Interface
{
    public interface IEmployeeRepository
    {
    

        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(int empid);
        Task<int> AddEmployes(Employee empdetail);
        Task<bool> DeleteEmployesById(int empid);
        Task<bool> UpdateEmploye(Employee empdetail);
    }
}
