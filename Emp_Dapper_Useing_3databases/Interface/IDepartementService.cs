using Emp_Dapper_Useing_3databases.Dtos;

namespace Emp_Dapper_Useing_3databases.Interface
{
    public interface IDepartementService
    {
        Task<List<DepartementDto>> GetDepartMentDetails();
        Task<DepartementDto> GetDepartmentDetailsById(int deptid);
        Task<int> AddDeparment(DepartementDto deptdetail);
        Task<bool> DeleteDepartmentById(int deptid);
        Task<bool> UpdateDepartment(DepartementDto deptdetail);
    }
}
