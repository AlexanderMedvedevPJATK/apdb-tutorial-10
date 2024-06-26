using Microsoft.EntityFrameworkCore;
using Tutorial10.Models;

namespace Tutorial10.Context;

public partial class Apbd10Context : DbContext
{
    public Apbd10Context()
    {
    }

    public Apbd10Context(DbContextOptions<Apbd10Context> options)
        : base(options)
    {
    }


    public DbSet<AppUser> Users { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    
}
