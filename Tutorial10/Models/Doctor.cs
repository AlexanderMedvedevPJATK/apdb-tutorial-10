using System.ComponentModel.DataAnnotations;

namespace Tutorial10.Models;

public class Doctor
{
    
    [Key]
    public int IdDoctor { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string FirstName { get; set; } = null!;
    
    [MaxLength(100)]
    [Required]
    public string LastName { get; set; } = null!;
    
    [EmailAddress]
    [MaxLength(100)]
    public string Email { get; set; } = null!;
}