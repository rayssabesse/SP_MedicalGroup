using SPMedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.Interfaces
{
    interface IDoctorJobRepository {
        List<DoctorJob> ListAll();
        DoctorJob SearchId(int id);
        void Register(DoctorJob newDoctorJob);
        void Refresh(int idDoctorJob, DoctorJob refreshDoctorJob);
        void Delete(int idDoctorJob);
        public List<DoctorJob> ListDoctors();
    }
}