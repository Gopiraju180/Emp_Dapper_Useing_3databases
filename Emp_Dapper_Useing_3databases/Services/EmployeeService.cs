using Emp_Dapper_Useing_3databases.Dtos;
using Emp_Dapper_Useing_3databases.Entites;
using Emp_Dapper_Useing_3databases.Interface;

namespace Emp_Dapper_Useing_3databases.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<int> AddEmployes(EmployeeDto empdetail)
        {
            Employee objEmp=new Employee();
            objEmp.empid=empdetail.empid;
            objEmp.empname=empdetail.empname;
            objEmp.empsalary=empdetail.empsalary;
            var res=await _employeeRepository.AddEmployes(objEmp);
            return res;
            
        }

        public async Task<bool> DeleteEmployesById(int empid)
        {
           await _employeeRepository.DeleteEmployesById(empid);
            return true;
        }

        public async Task<EmployeeDto> GetEmployeeById(int empid)
        {
           var res=await _employeeRepository.GetEmployeeById(empid);
            EmployeeDto empdto=new EmployeeDto();
            empdto.empid=res.empid;
            empdto.empname=res.empname;
            empdto.empsalary = res.empsalary;
            return empdto;
        }

        public async Task<List<EmployeeDto>> GetEmployees()
        {
            List<EmployeeDto>listempdto = new List<EmployeeDto>();
            var res = await _employeeRepository.GetEmployees();
            foreach(Employee emp in res)
            {
                EmployeeDto empdto = new EmployeeDto();
                empdto.empid=emp.empid;
                empdto.empname=emp.empname;
                empdto.empsalary = emp.empsalary;
                listempdto.Add(empdto);
            }
            return listempdto;
        }

        public async Task<bool> UpdateEmploye(EmployeeDto empdetail)
        {
            Employee emp = new Employee();
            emp.empid = empdetail.empid;
            emp.empname = empdetail.empname;
            emp.empsalary= empdetail.empsalary;
            await _employeeRepository.UpdateEmploye(emp);
            return true;
        }
    }
}
