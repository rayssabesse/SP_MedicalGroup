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
    public class UserTypeRepository : IUserTypeRepository
    {
        SPMedicalGroupContext ctx = new SPMedicalGroupContext();

        public void Delete(int idUserType)
        {
            UserType usertypeSearched = SearchId(idUserType);
            ctx.UserTypes.Remove(usertypeSearched);
            ctx.SaveChanges();
        }

        public List<UserType> ListAll()
        {
            return ctx.UserTypes.ToList();
        }

        public List<UserType> ListUsers()
        {
            return ctx.UserTypes.Include(c => c.Userrs).OrderBy(c => c.IdUserType).ToList();
        }

        public void Refresh(int idUserType, UserType refreshUserType)
        {
            UserType usertypeSearched = SearchId(idUserType);
            if (usertypeSearched != null)
            {
                usertypeSearched.UserType1 = refreshUserType.UserType1;
            }

            ctx.UserTypes.Update(usertypeSearched);
            ctx.SaveChanges();
        }

        public void Register(UserType newUserType)
        {
            ctx.UserTypes.Add(newUserType);
            ctx.SaveChanges();
        }

        public UserType SearchId(int id)
        {
            return ctx.UserTypes.FirstOrDefault(c => c.IdUserType == id);
        }
    }
}
