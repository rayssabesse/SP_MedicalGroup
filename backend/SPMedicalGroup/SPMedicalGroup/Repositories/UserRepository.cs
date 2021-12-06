using Microsoft.EntityFrameworkCore;
using SPMedicalGroup.Context;
using SPMedicalGroup.Domains;
using SPMedicalGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SPMedicalGroup.Repositories
{
    public class UserRepository : IUserrRepository
    {
        SPMedicalGroupContext ctx = new SPMedicalGroupContext();

        public void Delete(int idUser)
        {
            Userr userSearched = SearchId(idUser);
            ctx.Userrs.Remove(userSearched);
            ctx.SaveChanges(); 
        }

        public List<Userr> ListAll()
        {
            return ctx.Userrs.ToList();
        }

        public List<Userr> ListPatients()
        {
            return ctx.Userrs.Include(c => c.Patient).OrderBy(c => c.IdUser).ToList();
        }

        public List<Userr> ListDoctors()
        {
            return ctx.Userrs.Include(c => c.Doctor).OrderBy(c => c.IdUser).ToList();
        }

        public Userr Login(string email, string password)
        {
            return ctx.Userrs.FirstOrDefault(u => u.EmailUser == email && u.PasswordUser == password);
        }

        public void Refresh(int idUser, Userr refreshUser)
        {
            Userr userSearched = SearchId(idUser);

            if (userSearched != null)
            {
                userSearched.IdUserType = refreshUser.IdUserType;
                userSearched.EmailUser = refreshUser.EmailUser;
                userSearched.PasswordUser = refreshUser.PasswordUser;
            }

            ctx.Userrs.Update(userSearched);

            ctx.SaveChanges();

        }

        public void Register(Userr newUser)
        {
            ctx.Userrs.Add(newUser);
            ctx.SaveChanges();

        }

        public Userr SearchId(int id)
        {
            return ctx.Userrs.FirstOrDefault(c => c.IdUser == id);
        }
    }
}
