public interface IDepartmentService
{
    Task<List<Department>> GetDepartments();
    Task<bool> AddDepartment(Department department);
    Task<bool> DeleteDepartment(int id);
    Task<bool> ModifyDepartment(Department department);
    Task<Department?> GetDepartmentById(int id);
    Task<List<Department>> getDepartmentByCodeOrName(string keyword);
}