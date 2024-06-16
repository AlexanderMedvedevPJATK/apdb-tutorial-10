using System.ComponentModel.DataAnnotations;

namespace Tutorial10.DTOs;

public class DoctorShortInfoDTO
{
    
    public int IdDoctor { get; set; }
    public string FirstName { get; set; } = null!;
}