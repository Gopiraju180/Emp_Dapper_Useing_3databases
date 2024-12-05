using Emp_Dapper_Useing_3databases.Dtos;
using Emp_Dapper_Useing_3databases.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emp_Dapper_Useing_3databases.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartementController : ControllerBase
    {
        IDepartementService _departementService;
        public DepartementController(IDepartementService departementService)
        {
            _departementService = departementService;
        }
       
        // ==============
        [HttpPost]
        [Route("AddDepartment")]
        public async Task<IActionResult> Post([FromBody] DepartementDto deptdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var deptdata = await _departementService.AddDeparment(deptdto);
                    return StatusCode(StatusCodes.Status201Created, deptdata);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server not found");
            }
        }
       
        //=========
        [HttpDelete]
        [Route("DeleteDepartmentByEmpid/{deptid}")]
        public async Task<IActionResult> delete([FromRoute]int deptid)
        {
            if (deptid < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");//if input parameters wrongly sent or empty bad request comes
            }
            try
            {
                var deptdata=await _departementService.DeleteDepartmentById(deptid);
                if (deptdata == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Depatdata not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, "Deleted Successfully");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server not found");
            }
        }
        
        [HttpGet]
        [Route("GetDepartment")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var deptdata = await _departementService.GetDepartMentDetails();
                if(deptdata == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK,deptdata);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        
        //=======
        [HttpGet]
        [Route("GetDepartmentByDeptid/{deptid}")]
        public async Task<IActionResult>Get(int deptid)
        {
            if (deptid < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var deptdata=await _departementService.GetDepartmentDetailsById(deptid);
                return StatusCode(StatusCodes.Status200OK, deptdata);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server error");
            }
        }
        //========
       
        [HttpPut]
        [Route("UpdateDepartment")]
        public async Task<IActionResult> put([FromBody] DepartementDto deptdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var deptdata=await _departementService.UpdateDepartment(deptdto);
                    return StatusCode(StatusCodes.Status200OK, deptdata);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
    }
}
