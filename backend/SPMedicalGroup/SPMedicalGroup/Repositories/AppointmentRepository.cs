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
    public class AppointmentRepository : IAppointmentRepository
    {
        SPMedicalGroupContext ctx = new SPMedicalGroupContext();
        public void AddDescription(int idAppointment, Appointment descriptionAppointment)
        {
            throw new NotImplementedException();
        }

        public void Delete(int idAppointment)
        {
            Appointment appointmentSearched = SearchId(idAppointment);
            ctx.Appointments.Remove(appointmentSearched);
            ctx.SaveChanges();
        }

        public List<Appointment> ListAll()
        {
            return ctx.Appointments
                .Include(a => a.IdPatientNavigation)
                .Include(b => b.IdDoctorNavigation)
                .ToList();
        }

        public void Refresh(int idAppointment, Appointment refreshAppointment)
        {
            Appointment appointmentSearched = SearchId(idAppointment);

            if (appointmentSearched != null)
            {
                appointmentSearched.IdPatient = refreshAppointment.IdPatient;
                appointmentSearched.IdDoctor = refreshAppointment.IdDoctor;
                appointmentSearched.IdSituation= refreshAppointment.IdSituation;
                appointmentSearched.DateAppointment = refreshAppointment.DateAppointment;
                appointmentSearched.DescriptionAppointment = refreshAppointment.DescriptionAppointment;
            }

            ctx.Appointments.Update(appointmentSearched);
            ctx.SaveChanges();
        }

        public void Register(Appointment newAppointment)
        {
            ctx.Appointments.Add(newAppointment);
            ctx.SaveChanges(); 
        }

        public Appointment SearchId(int id)
        {
            return ctx.Appointments.FirstOrDefault(c => c.IdAppointment == id);
        }
    }
}
