//ใช้ EF core เพื่อเชื่อมต่อฐานข้อมูล
using Microsoft.EntityFrameworkCore;

//สร้างคลาส AppDbContext ที่สืบทอดจากคลาส DbContext
public class AppDbContext : DbContext
{
    //constructor ที่รับ DbContextOptions เพื่อกำหนดการเชื่อมต่อฐานข้อมูล
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    //กำหนด DbSet สำหรับตาราง department เพื่อใช้ในการติดต่อกับข้อมูลในตาราง
    public DbSet<Department> Departments { get; set; }

    // กำหนดการแมประหว่างคลาสกับตารางในฐานข้อมูล
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>().ToTable("Departments");
    }
}