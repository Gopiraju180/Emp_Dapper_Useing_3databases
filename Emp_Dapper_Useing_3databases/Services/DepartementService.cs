using Emp_Dapper_Useing_3databases.Dtos;
using Emp_Dapper_Useing_3databases.Entites;
using Emp_Dapper_Useing_3databases.Interface;

namespace Emp_Dapper_Useing_3databases.Services
{
    public class DepartementService : IDepartementService
    {
        private readonly IDepartmentRepository _repository;
        public DepartementService(IDepartmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> AddDeparment(DepartementDto deptdetail)
        {
            Departement objDpt=new Departement();
            objDpt.deptname = deptdetail.deptname;
            objDpt.deptlocation = deptdetail.deptlocation;
            objDpt.deptid = deptdetail.deptid;
             var res=await _repository.AddDeparment(objDpt);
            return res;
        }

        public async Task<bool> DeleteDepartmentById(int deptid)
        {
            await _repository.DeleteDepartmentById(deptid);
            return true;
        }

        public async Task<List<DepartementDto>> GetDepartMentDetails()
        {
            List<DepartementDto> listdto=new List<DepartementDto>();
            var res = await _repository.GetDepartMentDetails();
            foreach(Departement dept in res)
            {
                DepartementDto deptdto=new DepartementDto();
                deptdto.deptid = dept.deptid;
                deptdto.deptname = dept.deptname;
                deptdto.deptlocation= dept.deptlocation;
                listdto.Add(deptdto);
            }
            return listdto;
        }

        public async Task<DepartementDto> GetDepartmentDetailsById(int deptid)
        {
            var res=await _repository.GetDepartmentDetailsById(deptid);
            DepartementDto deptdto=new DepartementDto();
            deptdto.deptid=res.deptid;
            deptdto.deptname = res.deptname;
            deptdto.deptlocation = res.deptlocation;
            return deptdto;
        }

        public async Task<bool> UpdateDepartment(DepartementDto deptdetail)
        {
           Departement objDpt= new Departement();
            objDpt.deptid=deptdetail.deptid;
            objDpt.deptname=deptdetail.deptname;
            objDpt.deptlocation=deptdetail.deptlocation;
            await _repository.UpdateDepartment(objDpt);
            return true;
        }
    }
}
