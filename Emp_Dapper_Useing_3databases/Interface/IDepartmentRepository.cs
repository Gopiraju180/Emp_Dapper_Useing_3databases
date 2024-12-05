
using Emp_Dapper_Useing_3databases.Entites;
namespace Emp_Dapper_Useing_3databases.Interface;

public interface IDepartmentRepository
{
    Task<List<Departement>> GetDepartMentDetails();
    Task<Departement> GetDepartmentDetailsById(int deptid);
    Task<int> AddDeparment(Departement deptdetail);
    Task<bool> DeleteDepartmentById(int deptid);
    Task<bool> UpdateDepartment(Departement deptdetail);
}
