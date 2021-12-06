using SPMedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.Interfaces
{
    interface ISituationRepository
    {
        List<Situation> ListAll();
        Situation SearchId(int id);
        void Register (Situation newSituation);
        void Refresh (int idSituation, Situation refreshSituation);
        void Delete (int idSituation);
        public List<Situation> ListAppointments();
    }
}