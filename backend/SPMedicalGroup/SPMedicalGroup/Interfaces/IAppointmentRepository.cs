using SPMedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.Interfaces
{
    interface IAppointmentRepository
    {
        List<Appointment> ListAll();
        Appointment SearchId(int id);
        void Register(Appointment newAppointment);
        void Refresh(int idAppointment, Appointment refreshAppointment);
        void Delete(int idAppointment);
            

    }
}