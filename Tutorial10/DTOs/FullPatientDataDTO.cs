namespace Tutorial10.DTOs;

public class FullPatientDataDTO
{
    
    public int IdPatient { get; set; }
    
    public string FirstName { get; set; } = null!;
    
    public string LastName { get; set; } = null!;
    
    public DateTime Birthdate { get; set; }
    
    public List<PrescriptionInfoDTO> Prescriptions { get; set; } = null!;
}