using SPMedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.Interfaces
{
    interface IUserrRepository
    {
        List<Userr> ListAll();
        public List<Userr> ListPatients();
        public List<Userr> ListDoctors();
        Userr SearchId(int id);
        Userr Login(string email, string password);
        void Register(Userr newUser);
        void Refresh(int idUser, Userr refreshUser);
        void Delete(int idUser);
    }

}