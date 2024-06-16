using Tutorial10.Models;

namespace Tutorial10.DTOs;

public class PrescriptionInfoDTO
{
    
    public int IdPrescription { get; set; }
    
    public DateTime Date { get; set; }
    
    public DateTime DueDate { get; set; }

    public List<MedicamentWithNameDTO> Medicaments { get; set; } = null!;
    
    public DoctorShortInfoDTO Doctor { get; set; } = null!;
}