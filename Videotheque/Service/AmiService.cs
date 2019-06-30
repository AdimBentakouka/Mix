using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Model;

namespace Videotheque.Service
{
    class AmiService
    {
        public async Task AddAmi(string prenom, string nom, string email)
        {
            var context = await DataAccess.BooksDbContext.GetCurrent();
            Ami newAmi = new Ami { Prenom = prenom, Nom = nom, Email = email };
            context.Amis.Add(newAmi);
            await context.SaveChangesAsync();
        }

        public async Task EditAmi(int idAmi, string prenom, string nom, string email)
        {
            var context = await DataAccess.BooksDbContext.GetCurrent();
            context.Amis.Where(a => a.Id == idAmi).First().Prenom = prenom;
            context.Amis.Where(a => a.Id == idAmi).First().Nom = nom;
            context.Amis.Where(a => a.Id == idAmi).First().Email = email;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAmi(int idAmi)
        {
            var context = await DataAccess.BooksDbContext.GetCurrent();
            context.Remove(context.Amis.Where(a => a.Id == idAmi).First());
            await context.SaveChangesAsync();
        }


    }
}
