using SPMedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.Interfaces {
    interface IUserTypeRepository {
        List<UserType> ListAll();
        UserType SearchId(int id);
        void Register(UserType newUserType);
        void Refresh(int idUserType, UserType refreshUserType);
        void Delete(int idUserType);
        public List<UserType> ListUsers();
    }
}