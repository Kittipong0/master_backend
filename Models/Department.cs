using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class Department
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(10)]
    public required string DepartmentCode { get; set; }

    [Required]
    [MaxLength(100)]
    public required string DepartmentName { get; set; }

    public required bool IsActive { get; set; }
}