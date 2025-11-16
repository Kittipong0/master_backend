using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// เพิ่มการ config ระบบต่างๆ ของเว็ป

// เพิ่ม CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins(
            "http://localhost:4200",       
            "http://192.168.1.38:4200" 
        )
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

// เพิ่ม controller
builder.Services.AddControllers();
// เพิ่มการเชื่อมต่อฐานข้อมูล
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// เพิ่มแยกการใช้งานโค้ดของ repository และ service
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

var app = builder.Build();

// กำหนด ให้ใช้ Https redirection
//app.UseHttpsRedirection();

// กำหนดให้รู้จัก route ของ controller
app.MapControllers();

app.UseCors("AllowAngularApp");

app.Run();