using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tutorial10.Context;
using Tutorial10.DTOs;

namespace Tutorial10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        
        private readonly Apbd10Context _dbContext;
        
        public PatientsController(Apbd10Context dbContext)
        {
            _dbContext = dbContext;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(int id)
        {
            var patient = await _dbContext.Patients
                .Include(p => p.Prescriptions)
                    .ThenInclude(p => p.Doctor)
                .Include(p => p.Prescriptions)
                    .ThenInclude(p => p.Medicaments)
                        .ThenInclude(p => p.Medicament)
                .FirstOrDefaultAsync(p => p.IdPatient == id);
            
            if (patient == null)
            {
                return NotFound("Patient not found");
            }

            var fullPatientData = new FullPatientDataDTO
            {   
                IdPatient = patient.IdPatient,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Birthdate = patient.Birthdate,
                Prescriptions = patient.Prescriptions.Select(p => new PrescriptionInfoDTO
                {
                    IdPrescription = p.IdPrescription,
                    Date = p.Date,
                    DueDate = p.DueDate,
                    Doctor = new DoctorShortInfoDTO
                    {
                        IdDoctor = p.Doctor.IdDoctor,
                        FirstName = p.Doctor.FirstName
                    },
                    Medicaments = p.Medicaments.Select(pm => new MedicamentWithNameDTO
                    {
                        IdMedicament = pm.IdMedicament,
                        Name = pm.Medicament.Name,
                        Dose = pm.Dose,
                        Description = pm.Medicament.Description
                    }).ToList()
                }).ToList()
            };
            
            return Ok(fullPatientData);
        }
    }
}
