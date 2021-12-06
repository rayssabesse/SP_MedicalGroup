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
    public class ClinicRepository : IClinicRepository
    {
        SPMedicalGroupContext ctx = new SPMedicalGroupContext();
        public void Delete(int idClinic)
        {
            Clinic searchedClinic = SearchId(idClinic);
            ctx.Clinics.Remove(searchedClinic);
            ctx.SaveChanges();
        }

        public List<Clinic> ListAll()
        {
            return ctx.Clinics.ToList();   
        }

        public List<Clinic> ListDoctors()
        {
            return ctx.Clinics.Include(c => c.Doctors).OrderBy(c => c.IdClinic).ToList();
        }

        public void Refresh(int idClinic, Clinic refreshClinic)
        {
            Clinic clinicSearched = SearchId(idClinic);
            if (clinicSearched != null)
            {
                clinicSearched.AddressClinic = refreshClinic.AddressClinic;
                clinicSearched.OpenClinic = refreshClinic.OpenClinic;
                clinicSearched.CloseClinic = refreshClinic.CloseClinic;
                clinicSearched.CnpjClinic = refreshClinic.CnpjClinic;
                clinicSearched.NameClinic = refreshClinic.NameClinic;
                clinicSearched.SocialReason = refreshClinic.SocialReason;
            }
            ctx.Clinics.Update(clinicSearched);
            ctx.SaveChanges();
        }

        public void Register(Clinic newClinic)
        {
            ctx.Clinics.Add(newClinic);
            ctx.SaveChanges();
        }

        public Clinic SearchId(int id)
        {
            return ctx.Clinics.FirstOrDefault(c => c.IdClinic == id);
        }
    }
}
