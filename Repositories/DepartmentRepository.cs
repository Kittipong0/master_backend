using Microsoft.EntityFrameworkCore;

public class DepartmentRepository : IDepartmentRepository
{
    // ประกาศตัวแปรสำหรับการเรียกใช้ฐานข้อมูล
    private readonly AppDbContext _context;

    public DepartmentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Department>> findAllDepartments()
    {
        return await _context.Departments.OrderBy(d => d.DepartmentCode).ToListAsync();
    }

    public async Task<bool> CreateDepartment(Department department)
    {
        await _context.Departments.AddAsync(department);
        int result = await _context.SaveChangesAsync();
        bool isCreated = result > 0;
        return isCreated;
    }

    public async Task<bool> RemoveDepartment(int id)
    {
        var department = await _context.Departments.FindAsync(id);
        if (department == null)
        {
            return false;
        }
        _context.Departments.Remove(department);
        int result = await _context.SaveChangesAsync();
        bool isDeleted = result > 0;
        return isDeleted;
    }

    public async Task<bool> UpdateDepartment(Department department)
    {
        _context.Departments.Update(department);
        int result = await _context.SaveChangesAsync();
        bool isUpdated = result > 0;
        return isUpdated;
    }

    public async Task<Department?> findDepartmentById(int id)
    {
        return await _context.Departments.FindAsync(id);
    }

    public async Task<List<Department>> findDepartmentByCodeOrName(string keyword)
    {
        return await _context.Departments
            .Where(d => d.DepartmentCode.Contains(keyword) || d.DepartmentName.Contains(keyword))
            .ToListAsync();
    }

}
