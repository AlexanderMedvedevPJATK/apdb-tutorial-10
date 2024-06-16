using System.ComponentModel.DataAnnotations;

namespace Tutorial10.DTOs;

public class DoctorDTO
{
    
    public int IdDoctor { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string FirstName { get; set; } = null!;
    
    [MaxLength(100)]
    [Required]
    public string LastName { get; set; } = null!;
    
    [MaxLength(100)]
    [Required]
    public string Email { get; set; } = null!;
}