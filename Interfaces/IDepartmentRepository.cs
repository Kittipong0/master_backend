public interface IDepartmentRepository
{
    Task<List<Department>> findAllDepartments();
    Task<bool> CreateDepartment(Department department);
    Task<bool> RemoveDepartment(int id);
    Task<bool> UpdateDepartment(Department department);
    Task<List<Department>> findDepartmentByCodeOrName(string keyword);
    Task<Department?> findDepartmentById(int id);
    
}