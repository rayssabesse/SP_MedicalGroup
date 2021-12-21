using SPMedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.Interfaces
{
    interface IDoctorRepository
    {
        List<Doctor> ListAll();
        Doctor SearchId(int id);
        void Register (Doctor newDoctor);
        void Refresh (int idDoctor, Doctor refreshDoctor);
        void Delete (int idDoctor);
        public List<Appointment> ListAppointments();
    }
}