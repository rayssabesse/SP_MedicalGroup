using SPMedicalGroup.Context;
using SPMedicalGroup.Domains;
using SPMedicalGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SPMedicalGroup.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        SPMedicalGroupContext ctx = new SPMedicalGroupContext();
        public void Delete(int idPatient)
        {
            Patient patientSearched = SearchId(idPatient);
            ctx.Patients.Remove(patientSearched);
            ctx.SaveChanges();
        }

        public List<Patient> ListAll()
        {
            return ctx.Patients.ToList();
        }

        public List<Patient> ListAppointments()
        {
            return ctx.Patients.Include(c => c.Appointments).OrderBy(c => c.IdPatient).ToList();
        }

        public void Refresh(int idPatient, Patient refreshPatient)
        {
            Patient patientSearched = SearchId(idPatient);
            if (patientSearched != null)
            {
                patientSearched.IdUser = refreshPatient.IdUser;
                patientSearched.NamePatient = refreshPatient.NamePatient;
                patientSearched.DobPatient = refreshPatient.DobPatient;
                patientSearched.PhonePatient = refreshPatient.PhonePatient;
                patientSearched.RgPatient = refreshPatient.RgPatient;
                patientSearched.CpfPatient = refreshPatient.CpfPatient;
                patientSearched.AddressPatient = refreshPatient.AddressPatient;
            }

            ctx.Patients.Update(patientSearched);

            ctx.SaveChanges();
        }

        public void Register(Patient newPatient)
        {
            ctx.Patients.Add(newPatient);
            ctx.SaveChanges();
        }

        public Patient SearchId(int id)
        {
            return ctx.Patients.FirstOrDefault(c => c.IdPatient == id);
        }
    }
}
