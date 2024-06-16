using System.ComponentModel.DataAnnotations;

namespace Tutorial10.DTOs;

public class PrescriptionAddingDTO
{
    [Required]
    public PatientDTO Patient { get; set; } = null!;

    [Required]
    public List<MedicamentNoNameDTO> Medicaments { get; set; } = null!;

    [Required]
    public DoctorDTO Doctor { get; set; } = null!;

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public DateTime DueDate { get; set; }
}