using SPMedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.Interfaces
{
    interface IPatientRepository
    {
        List<Patient> ListAll();
        Patient SearchId(int id);
        void Register(Patient newPatient);
        void Refresh(int idPatient, Patient refreshPatient);
        void Delete(int idPatient);
        public List<Patient> ListAppointments();

    }
}