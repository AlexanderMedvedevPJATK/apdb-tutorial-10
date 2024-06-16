using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tutorial10.Models;

public class PrescriptionMedicament
{
    
    public int IdMedicament { get; set; }
    
    public int IdPrescription { get; set; }
    
    public int Dose { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string Details { get; set; } = null!;
    
    public Medicament Medicament { get; set; } = null!;
    public Prescription Prescription { get; set; } = null!;
}