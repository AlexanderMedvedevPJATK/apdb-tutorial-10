using System.ComponentModel.DataAnnotations;

namespace Tutorial10.DTOs;

public class MedicamentNoNameDTO
{
    public int IdMedicament { get; set; }
        
    [MaxLength(100)]
    [Required]
    public int Dose { get; set; }
        
    [MaxLength(100)]
    [Required]
    public string Description { get; set; } = null!;
}