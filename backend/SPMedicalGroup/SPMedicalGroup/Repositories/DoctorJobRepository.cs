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
    public class DoctorJobRepository : IDoctorJobRepository
    {
        SPMedicalGroupContext ctx = new SPMedicalGroupContext();

        public void Delete(int idDoctorJob)
        {
            DoctorJob doctorJobSearched = SearchId(idDoctorJob);
            ctx.DoctorJobs.Remove(doctorJobSearched);
            ctx.SaveChanges();
        }

        public List<DoctorJob> ListAll()
        {
            return ctx.DoctorJobs.ToList();
        }

        public List<DoctorJob> ListDoctors()
        {
            return ctx.DoctorJobs.Include(c => c.Doctors).OrderBy(c => c.IdDoctorJob).ToList();    
        }

        public void Refresh(int idDoctorJob, DoctorJob refreshDoctorJob)
        {
            DoctorJob doctorJobSearched = SearchId(idDoctorJob);
            if (doctorJobSearched != null)
            {
                doctorJobSearched.NameDoctorJob= refreshDoctorJob.NameDoctorJob;
            }

            ctx.DoctorJobs.Update(doctorJobSearched);
            ctx.SaveChanges();
        }

        public void Register(DoctorJob newDoctorJob)
        {
            ctx.DoctorJobs.Add(newDoctorJob);
            ctx.SaveChanges();
        }

        public DoctorJob SearchId(int id)
        {
            return ctx.DoctorJobs.FirstOrDefault(c => c.IdDoctorJob == id);
        }
    }
}
