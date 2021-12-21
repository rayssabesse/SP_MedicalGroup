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
    public class DoctorRepository : IDoctorRepository
    {
        SPMedicalGroupContext ctx = new SPMedicalGroupContext();
        public void Delete(int idDoctor)
        {
            Doctor searchedDoctor = SearchId(idDoctor);

            ctx.Doctors.Remove(searchedDoctor);

            ctx.SaveChanges();
        }

        public List<Doctor> ListAll()
        {
            return ctx.Doctors.ToList();
        }

        public List<Appointment> ListAppointments(int userID)
        {
            //return ctx.Doctors.Include(c => c.Appointments).OrderBy(c => c.IdDoctor).ToList();
            

            return ctx.Appointments.Select(a =>
                new Appointment()
                {
                    namePatient = a.IdPatientNavigation.NamePatient

                }

                 ).Where(a=> a.IdDoctor == userID).ToList();



        }

        public void Refresh(int idDoctor, Doctor refreshDoctor)
        {
            Doctor searchedDoctor = SearchId(idDoctor);
            if (searchedDoctor != null)
            {
                searchedDoctor.IdUser = refreshDoctor.IdUser;
                searchedDoctor.IdDoctorJob = refreshDoctor.IdDoctorJob;
                searchedDoctor.IdClinic = refreshDoctor.IdClinic;
                searchedDoctor.CrmDoctor = refreshDoctor.CrmDoctor;
                searchedDoctor.NameDoctor = refreshDoctor.NameDoctor;
            }

            ctx.Doctors.Update(searchedDoctor);

            ctx.SaveChanges();
        }

        public void Register(Doctor newDoctor)
        {
            ctx.Doctors.Add(newDoctor);

            ctx.SaveChanges();
        }

        public Doctor SearchId(int id)
        {
            return ctx.Doctors.FirstOrDefault(c => c.IdDoctor == id);
        }
    }
}
