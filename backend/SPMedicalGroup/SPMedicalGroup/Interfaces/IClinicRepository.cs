using SPMedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.Interfaces
{
    interface IClinicRepository
    {
        List<Clinic> ListAll();
        Clinic SearchId(int id);
        void Register (Clinic newClinic);
        void Refresh (int idClinic, Clinic refreshClinic);
        void Delete (int idClinic);
        public List<Clinic> ListDoctors();
    }
}