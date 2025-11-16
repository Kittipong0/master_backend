using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// ระบุว่าเป็น API Controller
[ApiController]
[Route("api/departments")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseObj>> ListDepartments()
    {
        List<Department> departments = await _departmentService.GetDepartments();
        return new ResponseObj
        {
            Code = Ok().StatusCode,
            Message = "Success",
            Data = departments
        };
    }

    [HttpPost]
    public async Task<ActionResult<ResponseObj>> CreateDepartment([FromBody] Dictionary<string, string> req)
    {
        string departmentCode = req.GetValueOrDefault("departmentCode") ?? "";
        string departmentName = req.GetValueOrDefault("departmentName") ?? "";
        bool isActive = req.GetValueOrDefault("isActive")?.ToLower() == "true" ? true : false;

        Department department = new Department
        {
            DepartmentCode = departmentCode,
            DepartmentName = departmentName,
            IsActive = isActive
        };

        bool isCreated = await _departmentService.AddDepartment(department);
        if (isCreated)
        {
            return Ok(new ResponseObj
            {
                Code = 200,
                Message = "Department created successfully",
            });
        }
        else
        {
            return BadRequest(new ResponseObj
            {
                Code = 400,
                Message = "Failed to create department",
            });
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ResponseObj>> DeleteDepartment(int id)
    {
        bool isDeleted = await _departmentService.DeleteDepartment(id);
        if (isDeleted)
        {
            return Ok(new ResponseObj
            {
                Code = 200,
                Message = "Department deleted successfully",
            });
        }
        else
        {
            return BadRequest(new ResponseObj
            {
                Code = 400,
                Message = "Failed to delete department",
            });
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ResponseObj>> UpdateDepartment(int id, [FromBody] Dictionary<string, string> req)
    {
        string departmentCode = req.GetValueOrDefault("departmentCode") ?? "";
        string departmentName = req.GetValueOrDefault("departmentName") ?? "";
        bool isActive = req.GetValueOrDefault("isActive")?.ToLower() == "true" ? true : false;
        Department department = new Department
        {
            Id = id,
            DepartmentCode = departmentCode,
            DepartmentName = departmentName,
            IsActive = isActive
        };
        bool isUpdated = await _departmentService.ModifyDepartment(department);
        if (isUpdated)
        {
            return Ok(new ResponseObj
            {
                Code = 200,
                Message = "Department updated successfully",
            });
        }
        else
        {
            return BadRequest(new ResponseObj
            {
                Code = 400,
                Message = "Failed to update department",
            });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ResponseObj>> GetDepartmentById(int id)
    {
        Department? department = await _departmentService.GetDepartmentById(id);
        if (department != null)
        {
            return Ok(new ResponseObj
            {
                Code = 200,
                Message = "Success",
                Data = department
            });
        }
        else
        {
            return NotFound(new ResponseObj
            {
                Code = 404,
                Message = "Department not found",
            });
        }
    }

    [HttpGet("search")]
    public async Task<ActionResult<ResponseObj>> SearchDepartmentByCodeOrName([FromQuery] string query)
    {
        List<Department> filteredDepartments = await _departmentService.getDepartmentByCodeOrName(query);
        return Ok(new ResponseObj
        {
            Code = 200,
            Message = "Success",
            Data = filteredDepartments
        });
    }

}