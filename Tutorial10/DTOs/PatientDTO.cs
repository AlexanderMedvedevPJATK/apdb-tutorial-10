using System.ComponentModel.DataAnnotations;

namespace Tutorial10.DTOs;

public class PatientDTO
{
    
    public int IdPatient { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string FirstName { get; set; } = null!;
    
    [MaxLength(100)]
    [Required]
    public string LastName { get; set; } = null!;
    
    [Required]
    public DateTime Birthdate { get; set; }
}