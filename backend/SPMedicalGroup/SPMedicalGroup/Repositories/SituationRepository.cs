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
    public class SituationRepository : ISituationRepository
    {
        SPMedicalGroupContext ctx = new SPMedicalGroupContext();
        public void Delete(int idSituation)
        {
            Situation situationSearched = SearchId(idSituation);
            ctx.Situations.Remove(situationSearched);
            ctx.SaveChanges();
        }

        public List<Situation> ListAll()
        {
            return ctx.Situations.ToList();
        }

        public List<Situation> ListAppointments()
        {
            return ctx.Situations.Include(c => c.Appointments).OrderBy(c => c.IdSituation).ToList();
        }

        public void Refresh(int idSituation, Situation refreshSituation)
        {
            Situation situationSearched = SearchId(idSituation);
            if (situationSearched != null)
            {
                situationSearched.TypeSituation = refreshSituation.TypeSituation;
            }
            ctx.Situations.Update(situationSearched);
            ctx.SaveChanges();
        }

        public void Register(Situation newSituation)
        {
            ctx.Situations.Add(newSituation);
            ctx.SaveChanges();
        }

        public Situation SearchId(int id)
        {
            return ctx.Situations.FirstOrDefault(c => c.IdSituation == id);
        }
    }
}
