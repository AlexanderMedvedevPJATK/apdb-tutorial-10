using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tutorial10.Context;
using Tutorial10.DTOs;
using Tutorial10.Models;

namespace Tutorial10.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        
        private readonly Apbd10Context _dbContext;
    
        public PrescriptionsController(Apbd10Context dbContext)
        {
            _dbContext = dbContext;
        }
        
        [HttpPost]
        public async Task<IActionResult> AddPrescription(PrescriptionAddingDTO request)
        {
            var patient = await _dbContext.Patients.FirstOrDefaultAsync(
                p => p.IdPatient == request.Patient.IdPatient);

            if (patient == null)
            {
                patient = new Patient
                {
                    IdPatient = request.Patient.IdPatient,
                    FirstName = request.Patient.FirstName,
                    LastName = request.Patient.LastName,
                    Birthdate = request.Patient.Birthdate
                };

                _dbContext.Patients.Add(patient);
            }
            
            var doctor = await _dbContext.Doctors.FirstOrDefaultAsync(
                d => d.IdDoctor == request.Doctor.IdDoctor);
            
            if (doctor == null)
            {
                doctor = new Doctor
                {
                    IdDoctor = request.Doctor.IdDoctor,
                    FirstName = request.Doctor.FirstName,
                    LastName = request.Doctor.LastName,
                    Email = request.Doctor.Email
                };

                _dbContext.Doctors.Add(doctor);
            }

            if (request.Medicaments.Count == 0)
            {
                return BadRequest("Prescription must contain at least one medicament");
            }
            
            if (request.Medicaments.Count > 10)
            {
                return BadRequest("Prescription can contain at most 10 medicaments");
            }
            
            foreach (var medicamentDTO in request.Medicaments)
            {
                var medicament = await _dbContext.Medicaments.FirstOrDefaultAsync(
                    m => m.IdMedicament == medicamentDTO.IdMedicament);

                if (medicament == null)
                {
                    return BadRequest("Medicament with id " + medicamentDTO.IdMedicament + " does not exist");
                }
            }
            
            if (request.Date > request.DueDate)
            {
                return BadRequest("Due date must be later than date or equal to date");
            }
            
            var prescription = new Prescription
            {
                Date = request.Date,
                DueDate = request.DueDate,
                IdPatient = patient.IdPatient,
                IdDoctor = doctor.IdDoctor
            };
            
            _dbContext.Prescriptions.Add(prescription);
            await _dbContext.SaveChangesAsync();
            
            return Ok();
        }
        
    }
}
