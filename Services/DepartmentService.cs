public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<List<Department>> GetDepartments()
    {
        return await _departmentRepository.findAllDepartments();
    }

    public async Task<bool> AddDepartment(Department department)
    {
        return await _departmentRepository.CreateDepartment(department);
    }

    public async Task<bool> DeleteDepartment(int id)
    {
        return await _departmentRepository.RemoveDepartment(id);
    }

    public async Task<bool> ModifyDepartment(Department department)
    {
        return await _departmentRepository.UpdateDepartment(department);
    }

    public async Task<Department?> GetDepartmentById(int id)
    {
        return await _departmentRepository.findDepartmentById(id);
    }

    public async Task<List<Department>> getDepartmentByCodeOrName(string keyword)
    {
        return await _departmentRepository.findDepartmentByCodeOrName(keyword);
    }
}
